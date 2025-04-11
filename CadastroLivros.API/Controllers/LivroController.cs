using CadastroLivros.Application.DTOs;
using CadastroLivros.Application.DTOs.Request;
using CadastroLivros.Application.DTOs.Response;
using CadastroLivros.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CadastroLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var livros = await _livroService.GetAllAsync();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var livro = await _livroService.GetByIdAsync(id);
            if (livro == null) return NotFound();
            return Ok(livro);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LivroRequest dto)
        {
            LivroResponse livroResponse = await _livroService.AddAsync(dto);
            return Ok(livroResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LivroRequest dto)
        {
            LivroResponse livroResponse = await _livroService.UpdateAsync(id, dto);
            return Ok(livroResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _livroService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("{livroId}/autores")]
        public async Task<IActionResult> AdicionarAutoresAoLivro(int livroId, [FromBody] AdicionarAutoresAoLivroRequest request)
        {
            var sucesso = await _livroService.AdicionarAutoresAoLivroAsync(livroId, request.AutoresIds);
            if (!sucesso)
                return NotFound();

            return NoContent();
        }

        [HttpPost("{livroId}/precos")]
        public async Task<IActionResult> AdicionarPrecosAoLivro(int livroId, [FromBody] List<PrecoLivroRequest> precosLivroRequest)
        {
            await _livroService.AdicionarPrecosAoLivroAsync(livroId, precosLivroRequest);
            return Ok();
        }
    }
}
