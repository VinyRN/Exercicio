using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Atendimento> Atendimentos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public void EnsureTableAndInsertData()
        {
            // Verificar se a tabela 'atendimentos' já existe
            var tableExists = this.Database.ExecuteSqlRaw(
                "SELECT CASE WHEN EXISTS (SELECT * FROM user_tables WHERE table_name = 'ATENDIMENTOS') THEN 1 ELSE 0 END"
            );

            // Se a tabela não existir, criar a tabela e inserir os dados
            if (tableExists == 0)
            {
                var createTableSql = @"
                    CREATE TABLE atendimentos (
                        id RAW(16) DEFAULT SYS_GUID() NOT NULL,
                        assunto VARCHAR2(100) NOT NULL,
                        ano NUMBER(4)
                    )";

                var insertDataSql = @"
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao atendimento', 2021);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao produto', 2021);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao produto', 2021);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro', 2021);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao atendimento', 2021);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao produto', 2021);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao produto', 2021);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao produto', 2021);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao produto', 2021);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao atendimento', 2021);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao atendimento', 2021);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao produto', 2022);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao produto', 2022);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao atendimento', 2022);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao atendimento', 2022);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao atendimento', 2022);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro', 2022);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro', 2022);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro', 2022);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro', 2022);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro', 2022);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro', 2022);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro', 2022);
                    INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro', 2022);
                    COMMIT;";

                // Executar comandos SQL
                this.Database.ExecuteSqlRaw(createTableSql);
                this.Database.ExecuteSqlRaw(insertDataSql);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atendimento>().HasKey(a => a.ID);
            base.OnModelCreating(modelBuilder);
        }
        public void SeedData()
        {
            if (!Atendimentos.Any())
            {
                Atendimentos.AddRange(new List<Atendimento>
                {
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao atendimento", Ano = 2021 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao produto", Ano = 2021 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao produto", Ano = 2021 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao cadastro", Ano = 2021 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao atendimento", Ano = 2021 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao produto", Ano = 2021 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao produto", Ano = 2021 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao produto", Ano = 2021 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao produto", Ano = 2021 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao atendimento", Ano = 2021 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao atendimento", Ano = 2021 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao produto", Ano = 2022 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao produto", Ano = 2022 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao atendimento", Ano = 2022 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao atendimento", Ano = 2022 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao atendimento", Ano = 2022 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao cadastro", Ano = 2022 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao cadastro", Ano = 2022 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao cadastro", Ano = 2022 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao cadastro", Ano = 2022 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao cadastro", Ano = 2022 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao cadastro", Ano = 2022 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao cadastro", Ano = 2022 },
                    new Atendimento { ID = Guid.NewGuid(), Assunto = "Reclamacao cadastro", Ano = 2022 }
                });

                SaveChanges();
            }
        }
    }
}
