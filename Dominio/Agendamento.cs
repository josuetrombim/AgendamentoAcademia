namespace AgendamentoAcademia.Dominio
{
    public class Agendamento
    {
        public int Id { get; set; }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; } = default!;

        public int AulaId { get; set; }
        public Aula Aula { get; set; } = default!;

        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    }
}
