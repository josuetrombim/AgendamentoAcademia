using AgendamentoAcademia.Dominio;
using AgendamentoAcademia.Infra;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoAcademia.Aplicacao;

public class SchedulingService
{
    private readonly ContextoBanco _db;
    public SchedulingService(ContextoBanco db) => _db = db;

    public async Task<(bool ok, string? erro)> AgendarAlunoAsync(int alunoId, int aulaId)
    {
        var aluno = await _db.Alunos.FindAsync(alunoId);
        if (aluno is null) return (false, "Aluno não encontrado.");

        var aula = await _db.Aulas.FindAsync(aulaId);
        if (aula is null) return (false, "Aula não encontrada.");

        // já agendado?
        if (await _db.Agendamentos.AnyAsync(a => a.AlunoId == alunoId && a.AulaId == aulaId))
            return (false, "Aluno já está agendado nessa aula.");

        // capacidade
        var ocupacao = await _db.Agendamentos.CountAsync(a => a.AulaId == aulaId);
        if (ocupacao >= aula.CapacidadeMaxima)
            return (false, "Capacidade máxima atingida.");

        // limite do plano
        var totalNoMes = await _db.Agendamentos
            .Include(x => x.Aula)
            .Where(x => x.AlunoId == alunoId &&
                        x.Aula.DataHora.Month == aula.DataHora.Month &&
                        x.Aula.DataHora.Year == aula.DataHora.Year)
            .CountAsync();

        var limite = PlanoLimites.ObterLimiteMensal(aluno.Plano);
        if (totalNoMes >= limite)
            return (false, $"Limite mensal atingido ({limite}).");

        _db.Agendamentos.Add(new Agendamento { AlunoId = alunoId, AulaId = aulaId });
        await _db.SaveChangesAsync();

        return (true, null);
    }
}
