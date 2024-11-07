using Microsoft.AspNetCore.Mvc;
using Questao5.Infrastructure.Persistence;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("api/contacorrente")]
    public class ContaController : ControllerBase
    {
        private readonly ContaCorrenteRepository _repository;

        public ContaController(ContaCorrenteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("saldo/{idConta}")]
        public async Task<IActionResult> ConsultarSaldo(string idConta)
        {
            if (!await _repository.ContaExisteAsync(idConta))
            {
                return BadRequest(new { TipoErro = "INVALID_ACCOUNT", Mensagem = "A conta não existe." });
            }

            if (!await _repository.ContaAtivaAsync(idConta))
            {
                return BadRequest(new { TipoErro = "INACTIVE_ACCOUNT", Mensagem = "A conta está inativa." });
            }

            var saldoResponse = await _repository.ObterSaldoAsync(idConta);
            return Ok(saldoResponse);
        }
    }

}
