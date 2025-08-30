using AgendamentoAcademia.Aplicacao;
using AgendamentoAcademia.Aplicacao.DTO;
using AgendamentoAcademia.Dominio;
using AgendamentoAcademia.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContextoBanco>(opt => 
   opt.UseSqlite("Data Source=academia.db"));

builder.Services.AddScoped<SchedulingService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("/", () => "API Academia Aulas");

// cadastro de alunos
app.MapPost("/alunos", async (Aluno aluno, ContextoBanco db) =>
{
    db.Alunos.Add(aluno);
    await db.SaveChangesAsync();
    return Results.Created($"/alunos/{aluno.Id}", aluno);
});

// cadastro de aulas
app.MapPost("/aulas", async (Aula aula, ContextoBanco db) =>
{
    db.Aulas.Add(aula);
    await db.SaveChangesAsync();
    return Results.Created($"/aulas/{aula.Id}", aula);
});

// agendar
app.MapPost("/aulas/{aulaId}/agendar/{alunoId}", async (int aulaId, int alunoId, SchedulingService svc) =>
{
    var (ok, erro) = await svc.AgendarAlunoAsync(alunoId, aulaId);
    return ok ? Results.Ok("Agendado!") : Results.BadRequest(erro);
});

app.MapGet("/alunos/{id}/relatorio", async (
    int id,
    [FromQuery] int? ano,
    [FromQuery] int? mes,
    ContextoBanco db) =>
{
    var aluno = await db.Alunos.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
    if (aluno is null)
        return Results.NotFound(new { error = "Aluno não encontrado." });

    var hoje = DateTime.UtcNow;
    var y = ano ?? hoje.Year;
    var m = mes ?? hoje.Month;

    var inicio = new DateTime(y, m, 1, 0, 0, 0, DateTimeKind.Utc);
    var fim = inicio.AddMonths(1);

    var agendamentos = await db.Agendamentos
        .Include(a => a.Aula)
        .Where(a => a.AlunoId == id && a.Aula.DataHora >= inicio && a.Aula.DataHora < fim)
        .ToListAsync();

    var total = agendamentos.Count;

    var tiposMais = agendamentos
    .GroupBy(a => a.Aula.Tipo)
    .Select(g => new TipoMaisFrequenteDto
    {
        Tipo = g.Key,
        Quantidade = g.Count()
    })
    .OrderByDescending(x => x.Quantidade)
    .ToList();

    var resposta = new RelatorioAlunoResponse(
        aluno.Id,
        aluno.Nome,
        y,
        m,
        total,
        tiposMais
    );

    return Results.Ok(resposta);
})
.WithName("RelatorioPorAluno")
.WithOpenApi(op => new(op)
{
    Summary = "Relatório mensal do aluno",
    Description = "Retorna total de aulas agendadas no mês e os tipos de aula mais frequentes."
});

app.Run();

