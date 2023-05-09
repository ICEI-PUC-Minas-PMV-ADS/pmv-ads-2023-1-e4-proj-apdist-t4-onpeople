using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;

namespace OnPeople.Application.Services.Contracts.FuncionariosMetas
{
    public interface IFuncionarioMetaServices
    {
        Task<int> AssociarMetaAFuncionario(int funcionarioId, int metaId);
    }
}