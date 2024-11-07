using Questao4.Domain;

namespace Questao4.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Atendimento> Atendimentos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atendimento>().HasKey(a => a.ID);
            base.OnModelCreating(modelBuilder);
        }
    }
}
