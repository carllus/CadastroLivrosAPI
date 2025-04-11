using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Domain.Exceptions
{
    public class DatabaseException : DomainException
    {
        public DatabaseException(string message, Exception innerException)
            : base(500, "Database Error",
                  $"Erro no banco de dados: {message}")
        {
        }
    }
}
