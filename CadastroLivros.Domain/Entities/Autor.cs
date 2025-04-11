using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Domain.Entities
{
    public class Autor
    {
        public int Id { get; set; }

        [Required]
        public required string Nome { get; set; }
        
        public ICollection<LivroAutor>? LivrosAutores { get; set; }
    }
}
