using CadastroLivros.Application.DTOs;
using CadastroLivros.Application.DTOs.Request;
using CadastroLivros.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Application.Interfaces
{
    public interface ILivroService
    {
        Task<LivroResponse> GetByIdAsync(int id);
        Task<IEnumerable<LivroResponse>> GetAllAsync();
        Task<LivroResponse> AddAsync(LivroRequest livroRequest);
        Task<LivroResponse> UpdateAsync(int id, LivroRequest livroRequest);
        Task DeleteAsync(int id);
        Task<bool> AdicionarAutoresAoLivroAsync(int livroId, List<int> autoresIds);
        Task<bool> AdicionarPrecosAoLivroAsync(int livroId, List<PrecoLivroRequest> precoLivroRequests);

    }
}
