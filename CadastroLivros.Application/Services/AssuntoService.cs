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
    public class AssuntoService : IAssuntoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AssuntoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AssuntoResponse> AddAsync(AssuntoRequest assuntoRequest)
        {
            Assunto assunto = _mapper.Map<Assunto>(assuntoRequest);
            _context.Assuntos.Add(assunto);
            await _context.SaveChangesAsync();

            return _mapper.Map<AssuntoResponse>(assunto);
        }

        public async Task DeleteAsync(int id)
        {
            var assunto = await _context.Assuntos.FindAsync(id);
            _context.Assuntos.Remove(assunto);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AssuntoResponse>> GetAllAsync()
        {
            var assuntos = await _context.Assuntos.ToListAsync();
            return _mapper.Map<IEnumerable<AssuntoResponse>>(assuntos);
        }

        public async Task<AssuntoResponse> GetByIdAsync(int id)
        {
            var assunto = await _context.Assuntos.FindAsync(id);
            return _mapper.Map<AssuntoResponse>(assunto);
        }

        public async Task<AssuntoResponse> UpdateAsync(int id, AssuntoRequest assuntoDto)
        {
            var assunto = _mapper.Map<Assunto>(assuntoDto);
            assunto.Id = id;
            _context.Entry(assunto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return _mapper.Map<AssuntoResponse>(assunto);
        }
    }
}
