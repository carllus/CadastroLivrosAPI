using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Domain.Exceptions
{
    public class ConflictException : DomainException
    {
        public ConflictException(string message)
            : base(409, "Conflict", message)
        {
        }
    }
}
