
using AutoMapper;
using OnPeople.Application.Dtos.Funcionarios;
using OnPeople.Domain.Models.Funcionarios;

namespace OnPeople.Application.Profiles
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<CreateFuncionarioDto, Funcionario>();
            CreateMap<Funcionario, ReadFuncionarioDto>();
            CreateMap<UpdateFuncionarioDto, Funcionario>();
        }
    }
}