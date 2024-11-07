using Microsoft.AspNetCore.Mvc;
using Questao2;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("api/calculadoraGols")]
    public class CalculadoraGolsController : ControllerBase
    {
        private readonly CalculadoraGols _calculadoraGols;

        public CalculadoraGolsController(CalculadoraGols calculadoraGols)
        {
            _calculadoraGols = calculadoraGols;
        }

        [HttpGet("calcular")]
        public async Task<IActionResult> CalcularGols(string team, int year)
        {
            if (string.IsNullOrEmpty(team))
            {
                return BadRequest("O nome do time é obrigatório.");
            }

            int totalGols = await _calculadoraGols.CalcularGolsAsync(team, year);
            return Ok(new
            {
                Mensagem = $"O time {team} marcou {totalGols} gols em {year}."
            });
        }
    }
}
