using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Domain.Exceptions
{
    public class NotFoundException : DomainException
    {
        public NotFoundException(string entityName, object key)
            : base(404, "Not Found",
                  $"A entidade '{entityName}' com o identificador '{key}' não foi encontrada.")
        {
        }
    }
}
