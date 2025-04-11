using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Application.DTOs.Request
{
    public class AdicionarAutoresAoLivroRequest
    {
        public List<int> AutoresIds { get; set; } = new();
    }
}
