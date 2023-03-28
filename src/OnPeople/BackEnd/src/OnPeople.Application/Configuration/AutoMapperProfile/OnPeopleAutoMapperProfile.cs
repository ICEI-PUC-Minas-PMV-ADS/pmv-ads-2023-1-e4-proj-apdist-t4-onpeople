using AutoMapper;
using OnPeople.Application.Dtos.Departamentos;
using OnPeople.Application.Dtos.Empresas;
using OnPeople.Application.Dtos.Users;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Domain.Models.Users;

namespace OnPeople.Application.Configuration.AutoMapperProfile
{
    public class OnPeopleAutoMapperProfile : Profile
    {
        public OnPeopleAutoMapperProfile() {
            CreateMap<Empresa, EmpresaDto>().ReverseMap();

            CreateMap<Empresa, AtualizarEmpresaAtivaDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<User, UserVisaoDto>().ReverseMap();

            CreateMap<Departamento, DepartamentoDto>().ReverseMap();
            
        }
    }
}