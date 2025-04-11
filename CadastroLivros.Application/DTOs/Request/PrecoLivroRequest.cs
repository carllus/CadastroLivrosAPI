using CadastroLivros.Application.DTOs.Request;

namespace CadastroLivros.Application.DTOs.Request
{
    public class PrecoLivroRequest
    {
        public string TipoCompra { get; set; } //balcao, internet, etc.
        public decimal Valor { get; set; }
    }
}
