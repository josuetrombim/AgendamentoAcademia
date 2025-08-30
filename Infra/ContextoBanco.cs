using AgendamentoAcademia.Dominio;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoAcademia.Infra
{
    public class ContextoBanco : DbContext
    {
        public ContextoBanco(DbContextOptions<ContextoBanco> options) : base(options) { }
        public DbSet<Aluno> Alunos => Set<Aluno>();
        public DbSet<Aula> Aulas => Set<Aula>();
        public DbSet<Agendamento> Agendamentos => Set<Agendamento>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendamento>(b =>
            {
                b.HasIndex(p => new { p.AlunoId, p.AulaId }).IsUnique();
            });
        }
    }
}
