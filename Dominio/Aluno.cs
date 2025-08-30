namespace AgendamentoAcademia.Dominio
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; } = default!;
        public Plano Plano { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}
