using Moq;
using FluentAssertions;
using CadastroLivros.API.Controllers;
using CadastroLivros.Application.Interfaces;
using CadastroLivros.Application.DTOs.Request;
using CadastroLivros.Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace CadastroLivros.Tests
{
    public class AutorControllerTests
    {
        private readonly Mock<IAutorService> _autorServiceMock;
        private readonly AutorController _controller;

        public AutorControllerTests()
        {
            _autorServiceMock = new Mock<IAutorService>();
            _controller = new AutorController(_autorServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_DeveRetornarOkComListaDeAutores()
        {
            var autoresMock = new List<AutorResponse> { new AutorResponse { Id = 1, Nome = "Autor Teste" } };
            _autorServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(autoresMock);

            var result = await _controller.GetAll();

            result.Should().BeOfType<OkObjectResult>();
            (result as OkObjectResult)?.Value.Should().BeEquivalentTo(autoresMock);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFound_QuandoAutorNaoExiste()
        {
            _autorServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((AutorResponse)null);

            var result = await _controller.GetById(42);

            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Create_DeveRetornarOkComAutorCriado()
        {
            var autorRequest = new AutorRequest { Nome = "Novo Autor" };
            var autorResponse = new AutorResponse { Id = 1, Nome = "Novo Autor" };

            _autorServiceMock.Setup(x => x.AddAsync(autorRequest)).ReturnsAsync(autorResponse);

            var result = await _controller.Create(autorRequest);

            result.Should().BeOfType<OkObjectResult>();
            (result as OkObjectResult)?.Value.Should().BeEquivalentTo(autorResponse);
        }
    }
}
