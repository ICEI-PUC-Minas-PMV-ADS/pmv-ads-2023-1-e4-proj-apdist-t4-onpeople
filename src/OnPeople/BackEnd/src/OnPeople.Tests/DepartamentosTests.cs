using Xunit;
using OnPeople.Application.Services.Contracts.Departamentos;
using OnPeople.Application.Services.Implementations.Departamentos;
using Moq;
using AutoMapper;
using OnPeople.Persistence.Interfaces.Contracts.Departamentos;
using OnPeople.Persistence.Interfaces.Contracts.Shared;
using Microsoft.Extensions.Logging;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Application.Dtos.Departamentos;

namespace OnPeople.Tests;
public class DepartamentosTests
{
    private readonly DepartamentosServices _departamentosServices;
    private readonly Mock<ISharedPersistence> sharedPersistenceMock;
    private readonly Mock<IDepartamentosPersistence> departamentosPersistenceMock;
    private readonly Mock<IMapper> mapperMock;

    private readonly IMapper _mapper;
    public DepartamentosTests()
    {
        sharedPersistenceMock = new Mock<ISharedPersistence>();
        departamentosPersistenceMock = new Mock<IDepartamentosPersistence>();
        mapperMock = new Mock<IMapper>();

        _departamentosServices = new DepartamentosServices(
            sharedPersistenceMock.Object,
            departamentosPersistenceMock.Object,
            mapperMock.Object
        );
    }
    
    [Fact]
    public async Task GetAllDepartamentosAsync_Sucesso()
    {
        var departamentosConsultados = await _departamentosServices.GetAllDepartamentosAsync();
        //var departamento = _mapper.Map<PageList<DepartamentoDto>>(resultado);

        Assert.Null(departamentosConsultados);
    }
}






