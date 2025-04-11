using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Domain.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public ICollection<LivroAutor> Autores { get; set; } = new List<LivroAutor>();
        public ICollection<LivroAssunto> Assuntos { get; set; } = new List<LivroAssunto>();
        public ICollection<PrecoLivro> Precos { get; set; } = new List<PrecoLivro>();
    }
}
