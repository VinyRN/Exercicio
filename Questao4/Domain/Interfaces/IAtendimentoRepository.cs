namespace Questao4.Domain.Interfaces
{
    public interface IAtendimentoRepository
    {
        Task<bool> TableExistsAsync();
        Task CreateTableAsync();
        Task<IEnumerable<Atendimento>> GetAllAsync();
    }
}
