using CadastroLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Application.DTOs.Request
{
    public class AutorRequest
    {
        [Required]
        public required string Nome { get; set; }
    }
}
