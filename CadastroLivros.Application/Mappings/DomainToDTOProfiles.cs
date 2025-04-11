using AutoMapper;
using CadastroLivros.Application.DTOs.Request;
using CadastroLivros.Application.DTOs.Response;
using CadastroLivros.Domain.Entities;

namespace CadastroLivros.Application.Mappings
{
    public class DomainDTOProfiles : Profile
    {
        public DomainDTOProfiles()
        {
            CreateMap<Assunto, AssuntoRequest>().ReverseMap();
            CreateMap<Assunto, AssuntoResponse>().ReverseMap();
            
            CreateMap<Autor, AutorRequest>().ReverseMap();
            CreateMap<Autor, AutorResponse>().ReverseMap();
            
            CreateMap<Livro, LivroRequest>().ReverseMap();
            CreateMap<LivroRequest, Livro>();
            CreateMap<Livro, LivroResponse>()
                .ForMember(dest => dest.Autores,
                            opt => opt.MapFrom(src => src.Autores.Select(la => la.Autor)));
            
            CreateMap<AutorResponse, LivroAutor>()
            .ForMember(dest => dest.AutorId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.LivroId, opt => opt.Ignore())
            .ForMember(dest => dest.Livro, opt => opt.Ignore())
            .ForMember(dest => dest.Autor, opt => opt.Ignore());

            CreateMap<PrecoLivro, PrecoLivroRequest>().ReverseMap();
            CreateMap<PrecoLivro, PrecoLivroResponse>().ReverseMap();
        }
    }
}