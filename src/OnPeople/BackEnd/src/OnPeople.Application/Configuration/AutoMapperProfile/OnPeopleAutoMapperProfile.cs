using AutoMapper;
using OnPeople.Application.Dtos.Contas;
using OnPeople.Application.Dtos.Departamentos;
using OnPeople.Application.Dtos.Empresas;
using OnPeople.Domain.Models.Contas;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Domain.Models.Empresas;

namespace OnPeople.Application.Configuration.AutoMapperProfile
{
    public class OnPeopleAutoMapperProfile : Profile
    {
        public OnPeopleAutoMapperProfile() {
            CreateMap<Empresa, EmpresaDto>().ReverseMap();

            CreateMap<Conta, ContaDto>().ReverseMap();
            CreateMap<ContaFuncao, ContaFuncaoDto>().ReverseMap();
            CreateMap<Funcao, FuncaoDto>().ReverseMap();

            CreateMap<Departamento, DepartamentoDto>().ReverseMap();
            
        }
    }
}