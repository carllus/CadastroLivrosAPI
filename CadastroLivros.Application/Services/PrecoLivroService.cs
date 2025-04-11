using AutoMapper;
using CadastroLivros.Application.DTOs.Response;
using CadastroLivros.Application.Interfaces;
using CadastroLivros.Domain.Entities;
using CadastroLivros.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CadastroLivros.Application.Services
{
    public class PrecoLivroService : IPrecoLivroService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PrecoLivroService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(PrecoLivroResponse precoLivroDto)
        {
            var precoLivro = _mapper.Map<PrecoLivro>(precoLivroDto);
            _context.PrecosLivros.Add(precoLivro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var precoLivro = await _context.PrecosLivros.FindAsync(id);
            _context.PrecosLivros.Remove(precoLivro);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PrecoLivroResponse>> GetAllAsync()
        {
            var precosLivros = await _context.PrecosLivros.ToListAsync();
            return _mapper.Map<IEnumerable<PrecoLivroResponse>>(precosLivros);
        }

        public async Task<PrecoLivroResponse> GetByIdAsync(int id)
        {
            var precoLivro = await _context.PrecosLivros.FindAsync(id);
            return _mapper.Map<PrecoLivroResponse>(precoLivro);
        }

        public async Task UpdateAsync(PrecoLivroResponse precoLivroDto)
        {
            var precoLivro = _mapper.Map<PrecoLivro>(precoLivroDto);
            _context.Entry(precoLivro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
