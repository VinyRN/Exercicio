using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Dto;

namespace Questao5.Infrastructure.Persistence
{
    public class ContaCorrenteRepository
    {
        private readonly string _connectionString;

        public ContaCorrenteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> ContaExisteAsync(string idConta)
        {
            using var connection = new SqliteConnection(_connectionString);
            var result = await connection.QuerySingleOrDefaultAsync<int>(
                "SELECT COUNT(1) FROM contacorrente WHERE idcontacorrente = @IdConta", new { IdConta = idConta });
            return result > 0;
        }

        public async Task<bool> ContaAtivaAsync(string idConta)
        {
            using var connection = new SqliteConnection(_connectionString);
            var result = await connection.QuerySingleOrDefaultAsync<int>(
                "SELECT ativo FROM contacorrente WHERE idcontacorrente = @IdConta", new { IdConta = idConta });
            return result == 1;
        }

        public async Task<SaldoResponse> ObterSaldoAsync(string idConta)
        {
            using var connection = new SqliteConnection(_connectionString);
            var conta = await connection.QuerySingleOrDefaultAsync<SaldoResponse>(
                "SELECT numero AS NumeroConta, nome AS NomeTitular FROM contacorrente WHERE idcontacorrente = @IdConta",
                new { IdConta = idConta });

            if (conta == null)
                throw new Exception("Conta não encontrada.");

            conta.DataHoraConsulta = DateTime.Now;
            conta.SaldoAtual = await connection.QuerySingleOrDefaultAsync<decimal>(
                "SELECT IFNULL(SUM(CASE WHEN tipomovimento = 'C' THEN valor ELSE -valor END), 0) " +
                "FROM movimento WHERE idcontacorrente = @IdConta",
                new { IdConta = idConta });

            return conta;
        }
    }

}
