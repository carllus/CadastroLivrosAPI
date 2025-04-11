using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Domain.Entities
{
    public class PrecoLivro
    {
        public int Id { get; set; }
        public int LivroId { get; set; }
        public Livro? Livro { get; set; }
        public string TipoCompra { get; set; }  
        public decimal Valor { get; set; }
    }
}
