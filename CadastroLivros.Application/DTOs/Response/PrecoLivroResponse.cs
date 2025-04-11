using CadastroLivros.Application.DTOs.Request;

namespace CadastroLivros.Application.DTOs.Response
{
    public class PrecoLivroResponse
    {
        public int Id { get; set; }
        public int LivroId { get; set; }
        public string TipoCompra { get; set; } //balcão, internet, etc.
        public decimal Valor { get; set; }
    }
}
