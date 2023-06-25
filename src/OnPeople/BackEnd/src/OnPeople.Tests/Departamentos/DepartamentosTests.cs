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
using OnPeople.Integration.Models.Pages.Config;
using System.Security.Cryptography;
using OnPeople.Integration.Models.Dashboard;

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

        var pageParameter = departamentosFixture.ObterPageParametersMock();

        departamentosPersistenceMock
            .Setup(d => d.GetAllDepartamentosAsync(pageParameter, 1, true))
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

        var departamentosConsultados = await _departamentosServices.GetAllDepartamentosAsync(pageParameter, 1, true);

        //Assert

        Assert.True(departamentosConsultados.Count.Equals(2));
        Assert.IsType<PageList<DepartamentoDto>>(departamentosConsultados);
        departamentosPersistenceMock.Verify(p => p.GetAllDepartamentosAsync(pageParameter, 1, true), Times.Once);
    }

    [Fact]
    [Trait(nameof(IDepartamentosServices.GetAllDepartamentosAsync), "Insucesso")]
    public async Task GetAllDepartamentosAsync_DeveRetornarUmaListaVazia_QuandoNãoExistirDepartamentosCadastrados()
    {
        //Arrange

        var pageParameter = departamentosFixture.ObterPageParametersMock();

        departamentosPersistenceMock
            .Setup(d => d.GetAllDepartamentosAsync(pageParameter, 1, true))
            .ReturnsAsync(departamentosFixture.ObterListaVaziaDeDepartamentosMock());


        mapperMock
            .Setup(x => x.Map<PageList<DepartamentoDto>>(It.IsAny<IEnumerable<Departamento>>()))
            .Returns((List<Departamento> src) => new PageList<DepartamentoDto>
            { });

        //Act

        var departamentosConsultados = await _departamentosServices.GetAllDepartamentosAsync(pageParameter, 1, true);

        //Assert

        Assert.False(departamentosConsultados.Count > 0);
        departamentosPersistenceMock.Verify(p => p.GetAllDepartamentosAsync(pageParameter, 1, true), Times.Once);
    }

    [Fact]
    [Trait(nameof(IDepartamentosServices.GetDepartamentoByIdAsync), "Sucesso")]
    public async Task GetDepartamentoByIdAsync_DeveRetornarOsDadosDoDepartamento_QuandoOIdInformadoForValido()
    {
        //Arrange

        departamentosPersistenceMock
            .Setup(d => d.GetDepartamentoByIdAsync(7))
            .Callback<int>(Id => Assert.Equal(7, Id))
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
    public async Task GetDepartamentoByIdAsync_NaoDeveRetornarOsDadosDoDepartamento_QuandoOIdInformadoForInvalido()
    {
        //Arrange

        departamentosPersistenceMock
            .Setup(d => d.GetDepartamentoByIdAsync(100))
            .Callback<int>(Id => Assert.Equal(100, Id))
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
              .Setup(m => m.Map<Departamento>(It.IsAny<DepartamentoDto>()))
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

        mapperMock
              .Setup(m => m.Map<DepartamentoDto>(It.IsAny<Departamento>()))
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

        sharedPersistenceMock
            .Setup(c => c.Create<Departamento>(departamento))
            .Callback<Departamento>(departamento =>
            {
                Assert.Equal(4, departamento.Id);
                Assert.Equal("DepartamentoValido", departamento.NomeDepartamento);
                Assert.Equal("DEPVAL", departamento.Sigla);
                Assert.Equal(1, departamento.DiretorId);
                Assert.Equal(1, departamento.GerenteId);
                Assert.Equal(1, departamento.SupervisorId);
                Assert.Equal("2023-05-22", departamento.DataCriacao);
                Assert.True(departamento.Ativo);
                Assert.Equal(4, departamento.EmpresaId);
            });

        sharedPersistenceMock
            .Setup(s => s.SaveChangesAsync())
            .ReturnsAsync(true);

        departamentosPersistenceMock
            .Setup(g => g.GetDepartamentoByIdAsync(departamento.Id))
            .Callback<int>(Id => Assert.Equal(4, Id))
            .ReturnsAsync(departamentosFixture.ObterDepartamentoCriadoMock(departamento.Id));

        //Act

        var departamentoCriado = await _departamentosServices.CreateDepartamentos(departamentoDto);

        //Assert

        Assert.Equal(4, departamentoCriado.Id);
        Assert.IsType<DepartamentoDto>(departamentoCriado);
        departamentosPersistenceMock.Verify(p => p.GetDepartamentoByIdAsync(4), Times.Once);
        sharedPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IDepartamentosServices.CreateDepartamentos), "Insucesso")]
    public async Task CreateDepartamentos_NaoDeveRealizarAInclusaoDoDepartamento_QuandoOsDadosForemInvalidos()
    {
        //Arrange

        var departamentoDto = departamentosFixture.CriarDepartamentoInvalidoDtoMock();
        var departamento = departamentosFixture.CriarDepartamentoInvalidoMock();


        mapperMock
              .Setup(m => m.Map<Departamento>(It.IsAny<DepartamentoDto>()))
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

        mapperMock
              .Setup(m => m.Map<DepartamentoDto>(It.IsAny<Departamento>()))
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

        sharedPersistenceMock
            .Setup(c => c.Create<Departamento>(departamento));

        sharedPersistenceMock
            .Setup(s => s.SaveChangesAsync())
            .ReturnsAsync(false);

        //Act

        var departamentoCriado = await _departamentosServices.CreateDepartamentos(departamentoDto);

        //Assert

        Assert.Null(departamentoCriado);
        sharedPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IDepartamentosServices.DeleteDepartamento), "Sucesso")]
    public async Task DeleteDepartamento_DeveRealizarAExclusaoDoDepartamento_QuandoODepartamentoExistir()
    {
        //Arrange

        var departamento = departamentosFixture.ObterApenasUmDepartamentoMock(7);

        departamentosPersistenceMock
           .Setup(g => g.GetDepartamentoByIdAsync(7))
           .ReturnsAsync(departamentosFixture.ObterApenasUmDepartamentoMock(7));

        sharedPersistenceMock
            .Setup(c => c.Delete<Departamento>(departamento));

        sharedPersistenceMock
            .Setup(s => s.SaveChangesAsync())
            .ReturnsAsync(true);

        //Act

        var departamentoExcluido = await _departamentosServices.DeleteDepartamento(departamento.Id);

        //Assert

        Assert.True(departamentoExcluido);
        departamentosPersistenceMock.Verify(p => p.GetDepartamentoByIdAsync(7), Times.Once);
        sharedPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IDepartamentosServices.DeleteDepartamento), "Insucesso")]
    public async Task DeleteDepartamento_NaoDeveRealizarAExclusaoDoDepartamento_QuandoODepartamentoNaoExistir()
    {
        //Arrange

        var departamento = departamentosFixture.ObterApenasUmDepartamentoMock(7);

        departamentosPersistenceMock
           .Setup(g => g.GetDepartamentoByIdAsync(8))
           .ReturnsAsync(departamentosFixture.ObterApenasUmDepartamentoMock(8));

        sharedPersistenceMock
            .Setup(c => c.Delete<Departamento>(departamento));

        //Act

        var departamentoExcluido = await _departamentosServices.DeleteDepartamento(departamento.Id);

        //Assert

        Assert.False(departamentoExcluido);
        departamentosPersistenceMock.Verify(p => p.GetDepartamentoByIdAsync(7), Times.Once);
    }

    [Fact]
    [Trait(nameof(IDepartamentosServices.GetDashboard), "Sucesso")]
    public void GetDashboard_DeveRetornarOsDadosDoDashboard_QuandoExistirDadosCadastrados()
    {
        //Arrange

        departamentosPersistenceMock
            .Setup(d => d.GetDashboard(1))
            .Returns(departamentosFixture.ObterDashboardMock(1,7));

        //Act

        var dashboardConsultado = _departamentosServices.GetDashboard(1);

        //Assert

        Assert.Equal(77, dashboardConsultado.CountDepartamentos);
        Assert.IsType<DashboardDepartamento>(dashboardConsultado);
        departamentosPersistenceMock.Verify(p => p.GetDashboard(1), Times.Once);
    }

    [Fact]
    [Trait(nameof(IDepartamentosServices.GetDashboard), "Insucesso")]
    public void GetDashboard_NaoDeveRetornarOsDadosDoDashboard_QuandoNaoExistirDadosCadastrados()
    {
        //Arrange

        departamentosPersistenceMock
            .Setup(d => d.GetDashboard(1))
            .Returns(departamentosFixture.ObterDashboardMock(1, 8));

        //Act

        var dashboardConsultado = _departamentosServices.GetDashboard(1);

        //Assert

        Assert.Null(dashboardConsultado);
        departamentosPersistenceMock.Verify(p => p.GetDashboard(1), Times.Once);
    }

}


