using CadastroLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Infra.Interfaces
{
    public interface IRelatorioLivrosService
    {
        byte[] GerarRelatorioLivros(List<Livro> livros);
    }
}
