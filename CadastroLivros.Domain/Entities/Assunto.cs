using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Domain.Entities
{
    public class Assunto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<LivroAssunto> LivrosAssuntos { get; set; } = new List<LivroAssunto>();
    }
}
