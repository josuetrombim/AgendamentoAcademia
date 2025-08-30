using AgendamentoAcademia.Aplicacao.DTO;
namespace AgendamentoAcademia.Aplicacao
{
    public record RelatorioAlunoResponse(
        int AlunoId,
        string Nome,
        int Ano,
        int Mes,
        int TotalNoMes,
        IReadOnlyList<TipoMaisFrequenteDto> TiposMaisFrequentes
    );
}
