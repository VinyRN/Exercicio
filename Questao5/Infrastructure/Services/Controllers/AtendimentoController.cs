using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Persistence;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("api/atendimento")]
    public class AtendimentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AtendimentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atendimento>>> GetAllAtendimentos()
        {
            var atendimentos = await _context.Atendimentos.ToListAsync();
            return Ok(atendimentos);
        }

        [HttpGet("filtrarPorOcorrencias")]
        public async Task<ActionResult<IEnumerable<object>>> FiltrarAtendimentosComMaisDeTresOcorrencias()
        {
            var atendimentosFiltrados = await _context.Atendimentos
                .GroupBy(a => new { a.Assunto, a.Ano })
                .Where(g => g.Count() > 3)
                .Select(g => new
                {
                    Assunto = g.Key.Assunto,
                    Ano = g.Key.Ano,
                    Quantidade = g.Count()
                })
                .OrderByDescending(g => g.Ano)
                .ThenByDescending(g => g.Quantidade)
                .ToListAsync();

            if (atendimentosFiltrados.Count == 0)
            {
                return NotFound("Nenhum atendimento com mais de 3 ocorrências encontrado.");
            }

            return Ok(atendimentosFiltrados);
        }
    }
}
