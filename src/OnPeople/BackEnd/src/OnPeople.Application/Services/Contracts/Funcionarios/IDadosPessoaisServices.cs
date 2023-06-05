using OnPeople.Application.Dtos.Funcionarios;
using OnPeople.Domain.Models.Funcionarios;

namespace OnPeople.Application.Services.Contracts.Funcionarios
{
    public interface IDadosPessoaisServices
    {
        Task<DadoPessoalDto> CreateDadoPessoal(DadoPessoalDto dadoPessoalDto);
        Task<IEnumerable<DadoPessoalDto>> GetAllDadosPessoais();
        Task<DadoPessoalDto> GetDadoPessoalById(int dadoPessoalId);
        Task<DadoPessoal> UpdateDadoPessoal(int id, DadoPessoalDto model);
        Task<bool> DeleteDadoPessoal(int id);
        Task<IEnumerable<DadoPessoalDto>> GetAllDadosPessoaisByFuncionarioId(int funcionarioId);
    }
}