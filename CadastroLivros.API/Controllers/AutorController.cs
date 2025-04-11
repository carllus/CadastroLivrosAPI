using CadastroLivros.Application.DTOs.Request;
using CadastroLivros.Application.DTOs.Response;
using CadastroLivros.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastroLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : Controller
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var autores = await _autorService.GetAllAsync();
            return Ok(autores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            AutorResponse autorResponse = await _autorService.GetByIdAsync(id);
            if (autorResponse == null) return NotFound();
            return Ok(autorResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AutorRequest autorRequest)
        {
            AutorResponse autorResponse = await _autorService.AddAsync(autorRequest);
            return Ok(autorResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AutorRequest autorRequest)
        {
            AutorResponse autorResponse = await _autorService.UpdateAsync(id, autorRequest);
            return Ok(autorResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _autorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
