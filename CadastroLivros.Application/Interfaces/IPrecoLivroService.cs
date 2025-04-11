using CadastroLivros.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Application.Interfaces
{
    public interface IPrecoLivroService
    {
        Task<PrecoLivroResponse> GetByIdAsync(int id);
        Task<IEnumerable<PrecoLivroResponse>> GetAllAsync();
        Task AddAsync(PrecoLivroResponse precoLivroDto);
        Task UpdateAsync(PrecoLivroResponse precoLivroDto);
        Task DeleteAsync(int id);
    }
}
