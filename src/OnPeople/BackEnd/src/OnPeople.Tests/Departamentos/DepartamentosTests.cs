using Xunit;
using OnPeople.Application.Services.Contracts.Departamentos;
using OnPeople.Application.Services.Implementations.Departamentos;
using Moq;
using AutoMapper;
using OnPeople.Persistence.Interfaces.Contracts.Departamentos;
using OnPeople.Persistence.Interfaces.Contracts.Shared;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Application.Dtos.Departamentos;
using OnPeople.Tests.Departamentos;
using OnPeople.Domain.Models.Empresas;
using System;


namespace OnPeople.Tests.Departamentos;

public class DepartamentosServicesTests
{
    public readonly DepartamentosServices _departamentosServices;
    private readonly Mock<ISharedPersistence> sharedPersistenceMock;
    private readonly Mock<IDepartamentosPersistence> departamentosPersistenceMock;
    private readonly Mock<IMapper> mapperMock;
    private readonly CargosFixture departamentosFixture;
 

    public DepartamentosServicesTests()
    {
        sharedPersistenceMock = new Mock<ISharedPersistence>();
        departamentosPersistenceMock = new Mock<IDepartamentosPersistence>();
        mapperMock = new Mock<IMapper>();
        departamentosFixture = new CargosFixture();


        _departamentosServices = new DepartamentosServices(
            sharedPersistenceMock.Object,
            departamentosPersistenceMock.Object,
            mapperMock.Object
        );

    }

    [Fact]
    [Trait(nameof(IDepartamentosServices.GetAllDepartamentosAsync), "Sucesso")]
    public async Task GetAllDepartamentosAsync_DeveRetornarAListaDeDepartamentosCadastrados_QuandoExistirDepartamentosCadastrados()
    {
        //Arrange

        departamentosPersistenceMock
            .Setup(d => d.GetAllDepartamentosAsync())
            .ReturnsAsync(departamentosFixture.ObterDepartamentosMock());


        mapperMock
            .Setup(x => x.Map<PageList<DepartamentoDto>>(It.IsAny<IEnumerable<Departamento>>()))
            .Returns((List<Departamento> src) => new PageList<DepartamentoDto>
            {
                new DepartamentoDto
                {
                    Id = src[0].Id,
                    NomeDepartamento = src[0].NomeDepartamento,
                    Sigla = src[0].Sigla,
                    DiretorId = src[0].DiretorId,
                    GerenteId = src[0].GerenteId,
                    SupervisorId = src[0].SupervisorId,
                    DataCriacao = src[0].DataCriacao,
                    Ativo = src[0].Ativo,
                    EmpresaId = src[0].EmpresaId
                },
                new DepartamentoDto
                {
                    Id = src[1].Id,
                    NomeDepartamento = src[1].NomeDepartamento,
                    Sigla = src[1].Sigla,
                    DiretorId = src[1].DiretorId,
                    GerenteId = src[1].GerenteId,
                    SupervisorId = src[1].SupervisorId,
                    DataCriacao = src[1].DataCriacao,
                    Ativo = src[1].Ativo,
                    EmpresaId = src[1].EmpresaId
                }
            });

        //Act

        var departamentosConsultados = await _departamentosServices.GetAllDepartamentosAsync();

        //Assert

        Assert.True(departamentosConsultados.Count > 0);
        Assert.IsType<PageList<DepartamentoDto>>(departamentosConsultados);
        departamentosPersistenceMock.Verify(p => p.GetAllDepartamentosAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IDepartamentosServices.GetAllDepartamentosAsync), "Insucesso")]
    public async Task GetAllDepartamentosAsync_DeveRetornarUmaListaVazia_QuandoNãoExistirDepartamentosCadastrados()
    {
        //Arrange

        departamentosPersistenceMock
            .Setup(d => d.GetAllDepartamentosAsync())
            .ReturnsAsync(departamentosFixture.ObterListaVaziaDeDepartamentosMock());


        mapperMock
            .Setup(x => x.Map<PageList<DepartamentoDto>>(It.IsAny<IEnumerable<Departamento>>()))
            .Returns((List<Departamento> src) => new PageList<DepartamentoDto>
            { });

        //Act

        var departamentosConsultados = await _departamentosServices.GetAllDepartamentosAsync();

        //Assert

        Assert.False(departamentosConsultados.Count > 0);
        departamentosPersistenceMock.Verify(p => p.GetAllDepartamentosAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IDepartamentosServices.GetDepartamentoByIdAsync), "Sucesso")]
    public async Task GetDepartamentoByIdAsync_DeveRetornarOsDadosDoDepartamento_QuandoOIdInformadoForValido()
    {
        //Arrange

        departamentosPersistenceMock
            .Setup(d => d.GetDepartamentoByIdAsync(7))
            .ReturnsAsync(departamentosFixture.ObterApenasUmDepartamentoMock(7));


        mapperMock
            .Setup(x => x.Map<DepartamentoDto>(It.IsAny<Departamento>()))
            .Returns((Departamento src) => new DepartamentoDto
            {
                Id = src.Id,
                NomeDepartamento = src.NomeDepartamento,
                Sigla = src.Sigla,
                DiretorId = src.DiretorId,
                GerenteId = src.GerenteId,
                SupervisorId = src.SupervisorId,
                DataCriacao = src.DataCriacao,
                Ativo = src.Ativo,
                EmpresaId = src.EmpresaId
            });

        //Act

        var departamentoConsultado = await _departamentosServices.GetDepartamentoByIdAsync(7);

        //Assert

        Assert.Equal(7, departamentoConsultado.Id);
        Assert.IsType<DepartamentoDto>(departamentoConsultado);
        departamentosPersistenceMock.Verify(p => p.GetDepartamentoByIdAsync(7), Times.Once);
    }

    [Fact]
    [Trait(nameof(IDepartamentosServices.GetDepartamentoByIdAsync), "Insucesso")]
    public async Task GetDepartamentoByIdAsync_NãoDeveRetornarOsDadosDoDepartamento_QuandoOIdInformadoForInValido()
    {
        //Arrange

        departamentosPersistenceMock
            .Setup(d => d.GetDepartamentoByIdAsync(100))
            .ReturnsAsync(departamentosFixture.ObterApenasUmDepartamentoMock(100));


        mapperMock
            .Setup(x => x.Map<DepartamentoDto>(It.IsAny<Departamento>()))
            .Returns((Departamento src) => new DepartamentoDto
            {
                Id = src.Id,
                NomeDepartamento = src.NomeDepartamento,
                Sigla = src.Sigla,
                DiretorId = src.DiretorId,
                GerenteId = src.GerenteId,
                SupervisorId = src.SupervisorId,
                DataCriacao = src.DataCriacao,
                Ativo = src.Ativo,
                EmpresaId = src.EmpresaId
            });

        //Act

        var departamentoConsultado = await _departamentosServices.GetDepartamentoByIdAsync(100);

        //Assert

        Assert.Null(departamentoConsultado);
        departamentosPersistenceMock.Verify(p => p.GetDepartamentoByIdAsync(100), Times.Once);
        
    }

    [Fact]
    [Trait(nameof(IDepartamentosServices.CreateDepartamentos), "Sucesso")]
    public async Task CreateDepartamentos_DeveRealizarAInclusaoDoDepartamento_QuandoOsDadosForemValidos()
    {
        //Arrange

        var departamentoDto = departamentosFixture.CriarDepartamentoValidoDtoMock();
        var departamento = departamentosFixture.CriarDepartamentoValidoMock();


        mapperMock
            .Setup(x => x.Map<Departamento>(departamentoDto))
            .Returns((DepartamentoDto src) => new Departamento
            {
                Id = src.Id,
                NomeDepartamento = src.NomeDepartamento,
                Sigla = src.Sigla,
                DiretorId = src.DiretorId,
                GerenteId = src.GerenteId,
                SupervisorId = src.SupervisorId,
                DataCriacao = src.DataCriacao,
                Ativo = src.Ativo,
                EmpresaId = src.EmpresaId
            });

        sharedPersistenceMock
            .Setup(c => c.Create<Departamento>(departamento));

        sharedPersistenceMock
            .Setup(s => s.SaveChangesAsync())
            .ReturnsAsync(true);

    

        departamentosPersistenceMock
            .Setup(g => g.GetDepartamentoByIdAsync(4))
            .ReturnsAsync(departamentosFixture.ObterDepartamentoCriadoMock(4));

        mapperMock
          .Setup(m => m.Map<DepartamentoDto>(departamento))
          .Returns((Departamento source) => new DepartamentoDto
          {
              Id = source.Id,
              NomeDepartamento = source.NomeDepartamento,
              Sigla = source.Sigla,
              DiretorId = source.DiretorId,
              GerenteId = source.GerenteId,
              SupervisorId = source.SupervisorId,
              DataCriacao = source.DataCriacao,
              Ativo = source.Ativo,
              EmpresaId = source.EmpresaId
          });


        //Act

        var departamentoCriado = await _departamentosServices.CreateDepartamentos(departamentoDto);

        //Assert

        Assert.Equal(4, departamentoCriado.Id);
        Assert.IsType<DepartamentoDto>(departamentoCriado);
        departamentosPersistenceMock.Verify(p => p.GetDepartamentoByIdAsync(4), Times.Once);
        sharedPersistenceMock.Verify(s => s.Create<DepartamentoDto>(departamentoDto), Times.Once);
        sharedPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

}








