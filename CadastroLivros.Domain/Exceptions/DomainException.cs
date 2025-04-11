using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Domain.Exceptions
{
    public abstract class DomainException : Exception
    {
        public int StatusCode { get; }
        public string ErrorType { get; }

        protected DomainException(int statusCode, string errorType, string message)
            : base(message)
        {
            StatusCode = statusCode;
            ErrorType = errorType;
        }
    }
}
