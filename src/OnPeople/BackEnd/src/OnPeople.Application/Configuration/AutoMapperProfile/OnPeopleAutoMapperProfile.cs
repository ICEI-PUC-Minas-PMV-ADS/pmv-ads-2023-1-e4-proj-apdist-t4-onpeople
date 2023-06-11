using AutoMapper;
using OnPeople.Application.Dtos.Cargos;
using OnPeople.Application.Dtos.Departamentos;
using OnPeople.Application.Dtos.Empresas;
using OnPeople.Application.Dtos.Funcionarios;
using OnPeople.Application.Dtos.Users;
using OnPeople.Domain.Models.Cargos;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Domain.Models.Metas;
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
            
            CreateMap<Cargo, CargoDto>().ReverseMap();

            CreateMap<Funcionario, ReadFuncionarioDto>().ReverseMap();
            CreateMap<Funcionario, UpdateFuncionarioDto>().ReverseMap();
            CreateMap<Funcionario, CreateFuncionarioDto>().ReverseMap();

            CreateMap<Endereco, EnderecoDto>().ReverseMap();

            CreateMap<DadoPessoal, DadoPessoalDto>().ReverseMap();

            CreateMap<Meta, MetaDto>().ReverseMap();
        }
    }
}