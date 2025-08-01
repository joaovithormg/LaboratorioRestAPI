using AutoMapper;
using LaboratoriosRestAPI.Models;
using LaboratoriosRestAPI.DTOs;

namespace LaboratoriosRestAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Livro
            CreateMap<Livro, LivroDTO.ReadLivroDto>()
                .ForMember(dest => dest.Autores, opt => opt.MapFrom(src => src.Autores));
            CreateMap<LivroDTO.CreateLivroDto, Livro>();
            CreateMap<LivroDTO.UpdateLivroDto, Livro>();
            CreateMap<LivroDTO.UpdateLivroDto, LivroDTO.ReadLivroDto>();

            // Autor
            CreateMap<Autor, AutorDTO.ReadAutorDto>();
            CreateMap<AutorDTO.CreateAutorDto, Autor>();
            CreateMap<AutorDTO.UpdateAutorDto, Autor>();
            CreateMap<AutorDTO.UpdateAutorDto, AutorDTO.ReadAutorDto>();


            // Emprestimo
            CreateMap<Emprestimo, EmprestimoDTO.ReadEmprestimoDto>()
                .ForMember(dest => dest.Livro, opt => opt.MapFrom(src => src.Livro));
            CreateMap<EmprestimoDTO.CreateEmprestimoDto, Emprestimo>();
            CreateMap<EmprestimoDTO.UpdateEmprestimoDto, Emprestimo>();
        }
    }
}