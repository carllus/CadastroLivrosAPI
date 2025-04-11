using Moq;
using FluentAssertions;
using CadastroLivros.API.Controllers;
using CadastroLivros.Application.Interfaces;
using CadastroLivros.Application.DTOs.Request;
using CadastroLivros.Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace CadastroLivros.Tests
{
    public class AssuntoControllerTests
    {
        private readonly Mock<IAssuntoService> _assuntoServiceMock;
        private readonly AssuntoController _controller;

        public AssuntoControllerTests()
        {
            _assuntoServiceMock = new Mock<IAssuntoService>();
            _controller = new AssuntoController(_assuntoServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_DeveRetornarOkComListaDeAssuntos()
        {
            var assuntosMock = new List<AssuntoResponse> { new AssuntoResponse { Id = 1, Descricao = "Assunto Teste" } };
            _assuntoServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(assuntosMock);

            var result = await _controller.GetAll();

            result.Should().BeOfType<OkObjectResult>();
            (result as OkObjectResult)?.Value.Should().BeEquivalentTo(assuntosMock);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFound_QuandoAssuntoNaoExiste()
        {
            _assuntoServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((AssuntoResponse)null);

            var result = await _controller.GetById(999);

            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Create_DeveRetornarOkComAssuntoCriado()
        {
            var assuntoRequest = new AssuntoRequest { Descricao = "Novo Assunto" };
            var assuntoResponse = new AssuntoResponse { Id = 1, Descricao = "Novo Assunto" };

            _assuntoServiceMock.Setup(x => x.AddAsync(assuntoRequest)).ReturnsAsync(assuntoResponse);

            var result = await _controller.Create(assuntoRequest);

            result.Should().BeOfType<OkObjectResult>();
            (result as OkObjectResult)?.Value.Should().BeEquivalentTo(assuntoResponse);
        }
    }
}
