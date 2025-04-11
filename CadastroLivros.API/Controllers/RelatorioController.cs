using CadastroLivros.Application.DTOs;
using CadastroLivros.Application.DTOs.Request;
using CadastroLivros.Application.DTOs.Response;
using CadastroLivros.Application.Interfaces;
using CadastroLivros.Domain.Entities;
using CadastroLivros.Infra.Data;
using CadastroLivros.Infra.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatorioController : Controller
    {
        private readonly IRelatorioLivrosService _relatorioService;
        private readonly AppDbContext _context;

        public RelatorioController(AppDbContext context, IRelatorioLivrosService relatorioService)
        {
            _context = context;
            _relatorioService = relatorioService;
        }

        [HttpGet("livros/base64")]
        public async Task<IActionResult> RelatorioLivros()
        {
            List<Livro> livros = await _context.Livros
                .Include(l => l.Autores)
                .ThenInclude(la => la.Autor)
                .Include(l => l.Precos)
                .ToListAsync();

            var pdfBytes = _relatorioService.GerarRelatorioLivros(livros);
            var base64 = Convert.ToBase64String(pdfBytes);

            return Ok(new { pdfBase64 = base64 });
        }

    }
}
