using AutoMapper;
using OnPeople.Application.Dtos.Funcionarios;
using OnPeople.Application.Services.Contracts.Funcionarios;
using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contracts.Funcionarios;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Application.Services.Implementations.Funcionarios
{
    public class EnderecosServices : IEnderecosServices
    {
        private readonly IEnderecosPersistence _enderecosPersistence;
        private readonly ISharedPersistence _sharedPersistence;
        private readonly IMapper _mapper;
        public EnderecosServices(
            IEnderecosPersistence enderecosPersistence,
            ISharedPersistence sharedPersistence,
            IMapper mapper)
        {
            _enderecosPersistence = enderecosPersistence;
            _sharedPersistence = sharedPersistence;
            _mapper = mapper;
        }
        public async Task<EnderecoDto> CreateEndereco(EnderecoDto enderecoDto)
        {
        try
            {
                var endereco = _mapper.Map<Endereco>(enderecoDto);

                _sharedPersistence.Create<Endereco>(endereco);

                if (await _sharedPersistence.SaveChangesAsync())
                {
                    var enderecoRetorno = await _enderecosPersistence.GetEnderecoByIdAsync(endereco.Id);

                    return _mapper.Map<EnderecoDto>(enderecoRetorno);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<EnderecoDto>> GetAllEnderecos()
        {
            try
            {
                var enderecos = await _enderecosPersistence.GetAllEnderecosAsync();

                if (enderecos == null) return null;

                var enderecosMapper = _mapper.Map<IEnumerable<EnderecoDto>>(enderecos);

                return enderecosMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<EnderecoDto> GetEnderecoById(int enderecoId)
        {
            try
            {
                var endereco = await _enderecosPersistence.GetEnderecoByIdAsync(enderecoId);

                if (endereco == null) return null;

                var enderecoMapper = _mapper.Map<EnderecoDto>(endereco);

                return enderecoMapper;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        }

        public async Task<Endereco> UpdateEndereco(int enderecoId, EnderecoDto enderecoDto)
        {
            try
            {
                var endereco = await _enderecosPersistence.GetEnderecoByIdAsync(enderecoId);

                if (endereco == null) return null;

                var enderecoUpdate = _mapper.Map(enderecoDto, endereco);

                _enderecosPersistence.Update<Endereco>(enderecoUpdate);

                if (await _sharedPersistence.SaveChangesAsync())
                {
                    var enderecoMapper =  await _enderecosPersistence.GetEnderecoByIdAsync(enderecoUpdate.Id);
                    return _mapper.Map<Endereco>(enderecoMapper);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteEndereco(int enderecoId)
        {
            try
            {
                var endereco = await _enderecosPersistence.GetEnderecoByIdAsync(enderecoId);

                if (endereco == null) 
                    throw new Exception("Funcionário para deleção náo foi encontrado!"); 

                _enderecosPersistence.Delete<Endereco>(endereco);

                return await _sharedPersistence.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<EnderecoDto>> GetAllEnderecosByFuncionarioId(int funcionarioId)
        {
            try
            {
                var enderecos = await _enderecosPersistence.GetAllEnderecosByFuncionarioIdAsync(funcionarioId);

                if (enderecos == null) return null;

                var enderecosMapper = _mapper.Map<IEnumerable<EnderecoDto>>(enderecos);

                return enderecosMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
    }
}