using Moq;
using FluentAssertions;
using CadastroLivros.API.Controllers;
using CadastroLivros.Application.Interfaces;
using CadastroLivros.Application.DTOs.Request;
using CadastroLivros.Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace CadastroLivros.Tests
{
    public class LivroControllerTests
    {
        private readonly Mock<ILivroService> _livroServiceMock;
        private readonly LivroController _controller;

        public LivroControllerTests()
        {
            _livroServiceMock = new Mock<ILivroService>();
            _controller = new LivroController(_livroServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_DeveRetornarOkComListaDeLivros()
        {
            var livrosMock = new List<LivroResponse> { new LivroResponse { Id = 1, Titulo = "Livro Teste" } };
            _livroServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(livrosMock);

            var result = await _controller.GetAll();

            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult?.Value.Should().BeEquivalentTo(livrosMock);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFound_QuandoLivroNaoExiste()
        {
            _livroServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((LivroResponse)null);

            var result = await _controller.GetById(99);

            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Create_DeveRetornarOkComLivroCriado()
        {
            var livroRequest = new LivroRequest { Titulo = "Novo Livro" };
            var livroResponse = new LivroResponse { Id = 1, Titulo = "Novo Livro" };

            _livroServiceMock.Setup(x => x.AddAsync(livroRequest)).ReturnsAsync(livroResponse);

            var result = await _controller.Create(livroRequest);

            result.Should().BeOfType<OkObjectResult>();
            (result as OkObjectResult)?.Value.Should().BeEquivalentTo(livroResponse);
        }
    }
}
