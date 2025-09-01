namespace AgendamentoAcademia.Dominio
{
    public class Aula
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public DateTime DataHora { get; set; }
        public int CapacidadeMaxima { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; } 
    }
}
