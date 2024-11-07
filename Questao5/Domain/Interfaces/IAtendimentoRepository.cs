using Questao5.Domain.Entities;

namespace Questao5.Domain.Interfaces
{
    public interface IAtendimentoRepository
    {
        Task<bool> TableExistsAsync();
        Task CreateTableAsync();
        Task<IEnumerable<Atendimento>> GetAllAsync();
    }
}
