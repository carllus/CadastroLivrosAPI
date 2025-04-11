using CadastroLivros.Application.DTOs;
using CadastroLivros.Application.DTOs.Request;
using CadastroLivros.Application.DTOs.Response;
using CadastroLivros.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssuntoController : Controller
    {
        private readonly IAssuntoService _assuntoService;

        public AssuntoController(IAssuntoService assuntoService)
        {
            _assuntoService = assuntoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var assuntos = await _assuntoService.GetAllAsync();
            return Ok(assuntos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var assunto = await _assuntoService.GetByIdAsync(id);
            if (assunto == null) return NotFound();
            return Ok(assunto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AssuntoRequest dto)
        {
            AssuntoResponse assuntoResponse = await _assuntoService.AddAsync(dto);
            return Ok(assuntoResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AssuntoRequest assuntoRequest)
        {
            AssuntoResponse assuntoResponse = await _assuntoService.UpdateAsync(id, assuntoRequest);
            return Ok(assuntoResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _assuntoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
