using OnPeople.Application.Dtos.Funcionarios;
using OnPeople.Domain.Models.Funcionarios;

namespace OnPeople.Application.Services.Contracts.Funcionarios
{
    public interface IEnderecosServices
    {
        Task<EnderecoDto> CreateEndereco(EnderecoDto enderecoDto);
        Task<IEnumerable<EnderecoDto>> GetAllEnderecos();
        Task<EnderecoDto> GetEnderecoById(int enderecoId);
        Task<Endereco> UpdateEndereco(int id, EnderecoDto model);
        Task<bool> DeleteEndereco(int enderecoId);
        Task<IEnumerable<EnderecoDto>> GetAllEnderecosByFuncionarioId(int funcionarioId);
    }
}