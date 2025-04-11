using CadastroLivros.Application.Interfaces;
using CadastroLivros.Application.DTOs;
using CadastroLivros.Infra.Data;
using CadastroLivros.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CadastroLivros.Application.DTOs.Response;
using CadastroLivros.Application.DTOs.Request;


namespace CadastroLivros.Application.Services
{
    public class AutorService : IAutorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AutorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AutorResponse> AddAsync(AutorRequest autorRequest)
        {
            var autor = _mapper.Map<Autor>(autorRequest);
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();

            return _mapper.Map<AutorResponse>(autor);
        }

        public async Task DeleteAsync(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AutorResponse>> GetAllAsync()
        {
            var autores = await _context.Autores.ToListAsync();
            return _mapper.Map<IEnumerable<AutorResponse>>(autores);
        }

        public async Task<AutorResponse> GetByIdAsync(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            return _mapper.Map<AutorResponse>(autor);
        }

        public async Task<AutorResponse> UpdateAsync(int id, AutorRequest autorRequest)
        {
            var autor = _mapper.Map<Autor>(autorRequest);
            autor.Id = id;
            _context.Entry(autor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return _mapper.Map<AutorResponse>(autor);
        }
    }
}
