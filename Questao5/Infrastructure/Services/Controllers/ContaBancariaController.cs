using Microsoft.AspNetCore.Mvc;
using Questao1;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaBancariaController : ControllerBase
    {
        private static List<ContaBancaria> contas = new List<ContaBancaria>();

        [HttpPost("criar")]
        public IActionResult CriarConta(int numeroConta, string nomeTitular, double? depositoInicial = null)
        {
            ContaBancaria novaConta;
            if (depositoInicial.HasValue)
            {
                novaConta = new ContaBancaria(numeroConta, nomeTitular, depositoInicial.Value);
            }
            else
            {
                novaConta = new ContaBancaria(numeroConta, nomeTitular);
            }

            contas.Add(novaConta);
            return CreatedAtAction(nameof(ObterConta), new { numeroConta = novaConta.NumeroConta }, novaConta);
        }

        [HttpGet("{numeroConta}")]
        public IActionResult ObterConta(int numeroConta)
        {
            var conta = contas.Find(c => c.NumeroConta == numeroConta);
            if (conta == null)
            {
                return NotFound("Conta não encontrada.");
            }
            return Ok(conta);
        }

        [HttpPut("{numeroConta}/depositar")]
        public IActionResult Depositar(int numeroConta, double valor)
        {
            var conta = contas.Find(c => c.NumeroConta == numeroConta);
            if (conta == null)
            {
                return NotFound("Conta não encontrada.");
            }

            conta.Deposito(valor);
            return Ok(conta);
        }

        [HttpPut("{numeroConta}/sacar")]
        public IActionResult Sacar(int numeroConta, double valor)
        {
            var conta = contas.Find(c => c.NumeroConta == numeroConta);
            if (conta == null)
            {
                return NotFound("Conta não encontrada.");
            }

            conta.Saque(valor);
            return Ok(conta);
        }

        [HttpGet]
        public IActionResult ObterTodasContas()
        {
            return Ok(contas);
        }
    }
}
