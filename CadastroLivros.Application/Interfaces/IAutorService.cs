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
    public interface IAutorService
    {
        Task<AutorResponse> GetByIdAsync(int id);
        Task<IEnumerable<AutorResponse>> GetAllAsync();
        Task<AutorResponse> AddAsync(AutorRequest autorRequest);
        Task<AutorResponse> UpdateAsync(int id, AutorRequest autorRequest);
        Task DeleteAsync(int id);
    }
}
