using AutoMapper;
using CadastroLivros.Application.DTOs;
using CadastroLivros.Application.DTOs.Request;
using CadastroLivros.Application.DTOs.Response;
using CadastroLivros.Application.Interfaces;
using CadastroLivros.Domain.Entities;
using CadastroLivros.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CadastroLivros.Application.Services
{
    public class LivroService : ILivroService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LivroService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LivroResponse> AddAsync(LivroRequest livroRequest)
        {
            Livro livro = _mapper.Map<Livro>(livroRequest);
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            return _mapper.Map<LivroResponse>(livro);
        }

        public async Task DeleteAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LivroResponse>> GetAllAsync()
        {
            List<Livro> livros = await _context.Livros
                .Include(l => l.Autores)
                .ThenInclude(la => la.Autor)
                .Include(l => l.Precos)
                .ToListAsync();
            return _mapper.Map<IEnumerable<LivroResponse>>(livros);
        }

        public async Task<LivroResponse> GetByIdAsync(int id)
        {
           var livro = await _context.Livros
                        .Include(l => l.Autores)
                        .ThenInclude(la => la.Autor)
                        .FirstOrDefaultAsync(l => l.Id == id);
            return _mapper.Map<LivroResponse>(livro);
        }

        public async Task<LivroResponse> UpdateAsync(int id, LivroRequest livroRequest)
        {
            Livro livro = _mapper.Map<Livro>(livroRequest);
            livro.Id = id;
            _context.Entry(livro).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return _mapper.Map<LivroResponse>(livro);
        }

        public async Task<bool> AdicionarAutoresAoLivroAsync(int livroId, List<int> autoresIds)
        {
            var livro = await _context.Livros
                .Include(l => l.Autores)
                .FirstOrDefaultAsync(l => l.Id == livroId);

            if (livro == null)
                return false;

            foreach (var autorId in autoresIds)
            {
                var autorExiste = await _context.Autores.AnyAsync(a => a.Id == autorId);
                if (!autorExiste)
                    continue; 

                var jaExiste = livro.Autores.Any(la => la.AutorId == autorId);
                if (!jaExiste)
                {
                    livro.Autores.Add(new LivroAutor
                    {
                        LivroId = livroId,
                        AutorId = autorId
                    });
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AdicionarPrecosAoLivroAsync(int livroId, List<PrecoLivroRequest> precoLivroRequests)
        {
            var livro = await _context.Livros
                .Include(l => l.Autores)
                .FirstOrDefaultAsync(l => l.Id == livroId);

            if (livro == null)
                return false;

            foreach (var precoLivroRequest in precoLivroRequests)
            {
                var precoLivro = await _context.PrecosLivros.FirstOrDefaultAsync(a => a.TipoCompra == precoLivroRequest.TipoCompra && a.LivroId == livroId);
                if (precoLivro is not null)
                {
                    precoLivro.Valor = precoLivroRequest.Valor;
                    _context.PrecosLivros.Update(precoLivro);
                }
                else
                {
                    precoLivro = _mapper.Map<PrecoLivro>(precoLivroRequest);
                    _context.PrecosLivros.Add(new PrecoLivro()
                    {
                        LivroId = livroId,
                        TipoCompra = precoLivro.TipoCompra,
                        Valor = precoLivro.Valor,
                    });
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
