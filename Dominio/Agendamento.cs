namespace AgendamentoAcademia.Dominio
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int AulaId { get; set; }
        public Aula Aula { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
