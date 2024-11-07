using Questao5.Domain.Interfaces;

namespace Questao5.Application.Services
{
    public class AtendimentoService
    {
        private readonly IAtendimentoRepository _repository;

        public AtendimentoService(IAtendimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task EnsureTableExistsAsync()
        {
            if (!await _repository.TableExistsAsync())
            {
                await _repository.CreateTableAsync();
            }
        }
    }
}
