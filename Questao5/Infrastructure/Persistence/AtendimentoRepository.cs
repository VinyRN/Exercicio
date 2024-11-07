using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;

namespace Questao5.Infrastructure.Persistence
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly AppDbContext _context;

        public AtendimentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> TableExistsAsync()
        {
            var result = await _context.Database.ExecuteSqlRawAsync(
                "SELECT CASE WHEN EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Atendimentos') THEN 1 ELSE 0 END"
            );
            return result == 1;
        }

        public async Task CreateTableAsync()
        {
            await _context.Database.ExecuteSqlRawAsync(
                "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Atendimentos') " +
                "BEGIN " +
                "CREATE TABLE Atendimentos (ID UNIQUEIDENTIFIER PRIMARY KEY, Assunto NVARCHAR(255), Ano INT) " +
                "END"
            );
        }

        public async Task<IEnumerable<Atendimento>> GetAllAsync()
        {
            return await _context.Atendimentos.ToListAsync();
        }
    }
}
