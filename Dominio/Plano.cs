using System.ComponentModel;

namespace AgendamentoAcademia.Dominio
{
    public enum Plano
    {
        [Description("Mensal")]
        Mensal = 1,

        [Description("Trimestral")]
        Trimestral = 2,

        [Description("Anual")]
        Anual = 3
    }
    public static class PlanoLimites
    {
        public static int ObterLimiteMensal(Plano plano) => plano switch
        {
            Plano.Mensal => 12,
            Plano.Trimestral => 20,
            Plano.Anual => 30,
            _ => 0
        };
    }
}
