using AgendamentoAcademia.Dominio;
using System.Globalization;

namespace AgendamentoAcademia.Aplicacao.DTO
{

    public class CriarAlunoDTO 
    { 
        public string Nome { get; set; }
        public Plano PlanoTipo { get; set; }
    } 

    public class CriarAulaDTO
    {
        public string Tipo { get; set; } = default!;
        public DateTime DataHora { get; set; }
        public int CapacidadeMaxima { get; set; }
    }
    public class TipoMaisFrequenteDto
    {
        public string Tipo { get; set; } 
        public int Quantidade { get; set; }
    }

    public class RelatorioGeralAlunoDTO
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public int TotalNoMes { get; set; }
        public string TipoPlano { get; set; }
        public List<TipoMaisFrequenteDto> TiposMaisFrequentes { get; set; }
    }

    public class RelatorioAlunoDTO
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public Plano Plano { get; set; }
    }

}
