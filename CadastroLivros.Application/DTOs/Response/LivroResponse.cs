using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Application.DTOs.Response
{
    public class LivroResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public List<AutorResponse> Autores { get; set; } = new List<AutorResponse>();
        public List<PrecoLivroResponse> Precos { get; set; } = new List<PrecoLivroResponse>();
    }
}
