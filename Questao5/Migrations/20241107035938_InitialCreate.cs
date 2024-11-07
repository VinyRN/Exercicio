using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Questao5.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Assunto = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.ID);
                });

            // Inserindo dados de exemplo na tabela 'Atendimentos'
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao atendimento', 2021)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao produto', 2021)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao produto', 2021)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao cadastro', 2021)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao atendimento', 2021)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao produto', 2021)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao produto', 2021)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao produto', 2021)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao produto', 2021)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao atendimento', 2021)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao atendimento', 2021)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao produto', 2022)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao produto', 2022)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao atendimento', 2022)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao atendimento', 2022)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao atendimento', 2022)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao cadastro', 2022)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao cadastro', 2022)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao cadastro', 2022)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao cadastro', 2022)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao cadastro', 2022)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao cadastro', 2022)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao cadastro', 2022)");
            migrationBuilder.Sql("INSERT INTO Atendimentos (ID, Assunto, Ano) VALUES (NEWID(), 'Reclamacao cadastro', 2022)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimentos");
        }
    }
}
