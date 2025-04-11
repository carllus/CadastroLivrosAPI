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
    public interface IAssuntoService
    {
        Task<AssuntoResponse> GetByIdAsync(int id);
        Task<IEnumerable<AssuntoResponse>> GetAllAsync();
        Task<AssuntoResponse> AddAsync(AssuntoRequest assuntoDto);
        Task<AssuntoResponse> UpdateAsync(int id, AssuntoRequest assuntoDto);
        Task DeleteAsync(int id);
    }
}
