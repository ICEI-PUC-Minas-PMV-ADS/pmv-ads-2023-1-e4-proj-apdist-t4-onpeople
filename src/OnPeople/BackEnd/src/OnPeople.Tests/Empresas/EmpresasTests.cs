using Xunit;
using OnPeople.Application.Services.Contracts.Empresas;
using OnPeople.Application.Services.Implementations.Empresas;
using Moq;
using AutoMapper;
using OnPeople.Persistence.Interfaces.Contracts.Empresas;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Application.Dtos.Empresas;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Tests.Departamentos;

namespace OnPeople.Tests.Empresas;

public class EmpresasServicesTests
{
    public readonly EmpresasServices _empresasServices;
    private readonly Mock<IEmpresasPersistence> empresasPersistenceMock;
    private readonly Mock<IMapper> mapperMock;
    private readonly EmpresasFixture empresasFixture;


    public EmpresasServicesTests()
    {
        empresasPersistenceMock = new Mock<IEmpresasPersistence>();
        mapperMock = new Mock<IMapper>();
        empresasFixture = new EmpresasFixture();


        _empresasServices = new EmpresasServices(
            empresasPersistenceMock.Object,
            mapperMock.Object
        );

    }

    [Fact]
    [Trait(nameof(IEmpresasServices.GetAllEmpresasAsync), "Sucesso")]
    public async Task GetAllEmpresasAsync_DeveRetornarAListaDeEmpresasCadastradas_QuandoExistirEmpresasCadastradas()
    {
        //Arrange

        var pageParameter = empresasFixture.ObterPageParametersMock();

        empresasPersistenceMock
            .Setup(d => d.GetAllEmpresasAsync(pageParameter, 1, true))
            .ReturnsAsync(empresasFixture.ObterEmpresasMock());


        mapperMock
            .Setup(x => x.Map<PageList<EmpresaDto>>(It.IsAny<IEnumerable<Empresa>>()))
            .Returns((List<Empresa> src) => new PageList<EmpresaDto>
            {
                new EmpresaDto
                {
                    Id = src[0].Id,
                    Cnpj = src[0].Cnpj,
                    RazaoSocial = src[0].RazaoSocial,
                    PorteEmpresa = src[0].PorteEmpresa,
                    NaturezaJuridica = src[0].NaturezaJuridica,
                    OptanteSimples = src[0].OptanteSimples,
                    Filial = src[0].Filial,
                    NomeFantasia = src[0].NomeFantasia,
                    Ativa = src[0].Ativa,
                    SiglaEmpresa = src[0].SiglaEmpresa,
                    DataCadastro = src[0].DataCadastro,
                    PadraoEmail = src[0].PadraoEmail
                },
                new EmpresaDto
                {
                    Id = src[1].Id,
                    Cnpj = src[1].Cnpj,
                    RazaoSocial = src[1].RazaoSocial,
                    PorteEmpresa = src[1].PorteEmpresa,
                    NaturezaJuridica = src[1].NaturezaJuridica,
                    OptanteSimples = src[1].OptanteSimples,
                    Filial = src[1].Filial,
                    NomeFantasia = src[1].NomeFantasia,
                    Ativa = src[1].Ativa,
                    SiglaEmpresa = src[1].SiglaEmpresa,
                    DataCadastro = src[1].DataCadastro,
                    PadraoEmail = src[1].PadraoEmail
                }
            });

        //Act

        var empresasConsultadas = await _empresasServices.GetAllEmpresasAsync(pageParameter, 1, true);

        //Assert

        Assert.True(empresasConsultadas.Count.Equals(2));
        Assert.IsType<PageList<EmpresaDto>>(empresasConsultadas);
        empresasPersistenceMock.Verify(p => p.GetAllEmpresasAsync(pageParameter, 1, true), Times.Once);
    }

    [Fact]
    [Trait(nameof(IEmpresasServices.GetAllEmpresasAsync), "Insucesso")]
    public async Task GetAllEmpresasAsync_DeveRetornarUmaListaVazia_QuandoNãoExistirEmpresasCadastradas()
    {
        //Arrange

        var pageParameter = empresasFixture.ObterPageParametersMock();

        empresasPersistenceMock
            .Setup(d => d.GetAllEmpresasAsync(pageParameter, 1, true))
            .ReturnsAsync(empresasFixture.ObterListaVaziaDeEmpresasMock());


        mapperMock
            .Setup(x => x.Map<PageList<EmpresaDto>>(It.IsAny<IEnumerable<Empresa>>()))
            .Returns((List<Empresa> src) => new PageList<EmpresaDto>
            { });

        //Act

        var empresasConsultadas = await _empresasServices.GetAllEmpresasAsync(pageParameter, 1, true);

        //Assert

        Assert.False(empresasConsultadas.Count > 0);
        empresasPersistenceMock.Verify(p => p.GetAllEmpresasAsync(pageParameter, 1, true), Times.Once);
    }

    [Fact]
    [Trait(nameof(IEmpresasServices.GetEmpresaByIdAsync), "Sucesso")]
    public async Task GetEmpresaByIdAsync_DeveRetornarOsDadosDaEmpresa_QuandoOIdInformadoForValido()
    {
        //Arrange

        empresasPersistenceMock
            .Setup(d => d.GetEmpresaByIdAsync(7))
            .Callback<int>(Id => Assert.Equal(7, Id))
            .ReturnsAsync(empresasFixture.ObterApenasUmaEmpresaMock(7));


        mapperMock
            .Setup(x => x.Map<EmpresaDto>(It.IsAny<Empresa>()))
            .Returns((Empresa src) => new EmpresaDto
            {
                Id = src.Id,
                Cnpj = src.Cnpj,
                RazaoSocial = src.RazaoSocial,
                PorteEmpresa = src.PorteEmpresa,
                NaturezaJuridica = src.NaturezaJuridica,
                OptanteSimples = src.OptanteSimples,
                Filial = src.Filial,
                NomeFantasia = src.NomeFantasia,
                Ativa = src.Ativa,
                SiglaEmpresa = src.SiglaEmpresa,
                DataCadastro = src.DataCadastro,
                PadraoEmail = src.PadraoEmail
            });

        //Act

        var empresaConsultada = await _empresasServices.GetEmpresaByIdAsync(7);

        //Assert

        Assert.Equal(7, empresaConsultada.Id);
        Assert.IsType<EmpresaDto>(empresaConsultada);
        empresasPersistenceMock.Verify(p => p.GetEmpresaByIdAsync(7), Times.Once);
    }

    [Fact]
    [Trait(nameof(IEmpresasServices.GetEmpresaByIdAsync), "Insucesso")]
    public async Task GetEmpresaByIdAsync_NaoDeveRetornarOsDadosDaEmpresa_QuandoOIdInformadoForInvalido()
    {
        //Arrange

        empresasPersistenceMock
            .Setup(d => d.GetEmpresaByIdAsync(100))
            .Callback<int>(Id => Assert.Equal(100, Id))
            .ReturnsAsync(empresasFixture.ObterApenasUmaEmpresaMock(100));


        mapperMock
            .Setup(x => x.Map<EmpresaDto>(It.IsAny<Empresa>()))
            .Returns((Empresa src) => new EmpresaDto
            {
                Id = src.Id,
                Cnpj = src.Cnpj,
                RazaoSocial = src.RazaoSocial,
                PorteEmpresa = src.PorteEmpresa,
                NaturezaJuridica = src.NaturezaJuridica,
                OptanteSimples = src.OptanteSimples,
                Filial = src.Filial,
                NomeFantasia = src.NomeFantasia,
                Ativa = src.Ativa,
                SiglaEmpresa = src.SiglaEmpresa,
                DataCadastro = src.DataCadastro,
                PadraoEmail = src.PadraoEmail
            });

        //Act

        var empresaConsultada = await _empresasServices.GetEmpresaByIdAsync(100);

        //Assert

        Assert.Null(empresaConsultada);
        empresasPersistenceMock.Verify(p => p.GetEmpresaByIdAsync(100), Times.Once);
    }

    [Fact]
    [Trait(nameof(IEmpresasServices.CreateEmpresas), "Sucesso")]
    public async Task CreateEmpresas_DeveRealizarAInclusaoDaEmpresa_QuandoOsDadosForemValidos()
    {
        //Arrange

        var empresaDto = empresasFixture.CriarEmpresaValidaDtoMock();
        var empresa = empresasFixture.CriarEmpresaValidaMock();


        mapperMock
              .Setup(m => m.Map<Empresa>(It.IsAny<EmpresaDto>()))
              .Returns((EmpresaDto src) => new Empresa
              {
                  Id = src.Id,
                  Cnpj = src.Cnpj,
                  RazaoSocial = src.RazaoSocial,
                  PorteEmpresa = src.PorteEmpresa,
                  NaturezaJuridica = src.NaturezaJuridica,
                  OptanteSimples = src.OptanteSimples,
                  Filial = src.Filial,
                  NomeFantasia = src.NomeFantasia,
                  Ativa = src.Ativa,
                  SiglaEmpresa = src.SiglaEmpresa,
                  DataCadastro = src.DataCadastro,
                  PadraoEmail = src.PadraoEmail
              });

        mapperMock
              .Setup(m => m.Map<EmpresaDto>(It.IsAny<Empresa>()))
              .Returns((Empresa source) => new EmpresaDto
              {
                  Id = source.Id,
                  Cnpj = source.Cnpj,
                  RazaoSocial = source.RazaoSocial,
                  PorteEmpresa = source.PorteEmpresa,
                  NaturezaJuridica = source.NaturezaJuridica,
                  OptanteSimples = source.OptanteSimples,
                  Filial = source.Filial,
                  NomeFantasia = source.NomeFantasia,
                  Ativa = source.Ativa,
                  SiglaEmpresa = source.SiglaEmpresa,
                  DataCadastro = source.DataCadastro,
                  PadraoEmail = source.PadraoEmail
              });

        empresasPersistenceMock
            .Setup(c => c.Create<Empresa>(empresa))
            .Callback<Empresa>(empresa =>
            {
                Assert.Equal(4, empresa.Id);
                Assert.Equal("47873840000122", empresa.Cnpj);
                Assert.Equal("RCSO CONSULTORIA LTDA", empresa.RazaoSocial);
                Assert.Equal("Médio", empresa.PorteEmpresa);
                Assert.Equal("Sociedade por Ações", empresa.NaturezaJuridica);
                Assert.Equal("N", empresa.OptanteSimples);
                Assert.False(empresa.Filial);
                Assert.Equal("RCSO", empresa.NomeFantasia);
                Assert.True(empresa.Ativa);
                Assert.Equal("RCSO", empresa.SiglaEmpresa);
                Assert.Equal("2022-07-22", empresa.DataCadastro);
                Assert.Equal("rcso.com.br", empresa.PadraoEmail);
            });

        empresasPersistenceMock
            .Setup(s => s.SaveChangesAsync())
            .ReturnsAsync(true);

        empresasPersistenceMock
            .Setup(g => g.GetEmpresaByIdAsync(empresa.Id))
            .Callback<int>(Id => Assert.Equal(4, Id))
            .ReturnsAsync(empresasFixture.ObterEmpresaCriadaMock(empresa.Id));

        //Act

        var empresaCriada = await _empresasServices.CreateEmpresas(4, true, empresaDto);

        //Assert

        Assert.Equal(4, empresaCriada.Id);
        Assert.IsType<EmpresaDto>(empresaCriada);
        empresasPersistenceMock.Verify(p => p.GetEmpresaByIdAsync(4), Times.Once);
        empresasPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IEmpresasServices.CreateEmpresas), "Insucesso")]
    public async Task CreateEmpresas_NaoDeveRealizarAInclusaoDaEmpresa_QuandoOsDadosForemInvalidos()
    {
        //Arrange

        var empresaDto = empresasFixture.CriarEmpresaInvalidaDtoMock();
        var empresa = empresasFixture.CriarEmpresaInvalidaMock();

        mapperMock
              .Setup(m => m.Map<Empresa>(It.IsAny<EmpresaDto>()))
              .Returns((EmpresaDto src) => new Empresa
              {
                  Id = src.Id,
                  Cnpj = src.Cnpj,
                  RazaoSocial = src.RazaoSocial,
                  PorteEmpresa = src.PorteEmpresa,
                  NaturezaJuridica = src.NaturezaJuridica,
                  OptanteSimples = src.OptanteSimples,
                  Filial = src.Filial,
                  NomeFantasia = src.NomeFantasia,
                  Ativa = src.Ativa,
                  SiglaEmpresa = src.SiglaEmpresa,
                  DataCadastro = src.DataCadastro,
                  PadraoEmail = src.PadraoEmail
              });

        mapperMock
              .Setup(m => m.Map<EmpresaDto>(It.IsAny<Empresa>()))
              .Returns((Empresa source) => new EmpresaDto
              {
                  Id = source.Id,
                  Cnpj = source.Cnpj,
                  RazaoSocial = source.RazaoSocial,
                  PorteEmpresa = source.PorteEmpresa,
                  NaturezaJuridica = source.NaturezaJuridica,
                  OptanteSimples = source.OptanteSimples,
                  Filial = source.Filial,
                  NomeFantasia = source.NomeFantasia,
                  Ativa = source.Ativa,
                  SiglaEmpresa = source.SiglaEmpresa,
                  DataCadastro = source.DataCadastro,
                  PadraoEmail = source.PadraoEmail
              });

        empresasPersistenceMock
            .Setup(c => c.Create<Empresa>(empresa));

        empresasPersistenceMock
            .Setup(s => s.SaveChangesAsync())
            .ReturnsAsync(false);

        //Act

        var empresaCriada = await _empresasServices.CreateEmpresas(4, true, empresaDto);

        //Assert

        Assert.Null(empresaCriada);
        empresasPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IEmpresasServices.DeleteEmpresas), "Sucesso")]
    public async Task DeleteEmpresas_DeveRealizarAExclusaoDaEmpresa_QuandoAEmpresaExistir()
    {
        //Arrange

        var empresa = empresasFixture.ObterApenasUmaEmpresaMock(7);

        empresasPersistenceMock
           .Setup(g => g.GetEmpresaByIdAsync(7))
           .ReturnsAsync(empresasFixture.ObterApenasUmaEmpresaMock(7));

        empresasPersistenceMock
            .Setup(c => c.Delete<Empresa>(empresa));

        empresasPersistenceMock
            .Setup(s => s.SaveChangesAsync())
            .ReturnsAsync(true);

        //Act

        var empresaExcluida = await _empresasServices.DeleteEmpresas(empresa.Id);

        //Assert

        Assert.True(empresaExcluida);
        empresasPersistenceMock.Verify(p => p.GetEmpresaByIdAsync(7), Times.Once);
        empresasPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IEmpresasServices.DeleteEmpresas), "Insucesso")]
    public void DeleteEmpresas_NaoDeveRealizarAExclusaoDaEmpresa_QuandoAEmpresaNaoExistir()
    {
        //Arrange

        var empresa = empresasFixture.ObterApenasUmaEmpresaMock(7);

        empresasPersistenceMock
           .Setup(g => g.GetEmpresaByIdAsync(8))
           .ReturnsAsync(empresasFixture.ObterApenasUmaEmpresaMock(8));

        //Act & Assert

        var exception = Assert.ThrowsAsync<Exception>(async () => await _empresasServices.DeleteEmpresas(empresa.Id));

        empresasPersistenceMock.Verify(p => p.GetEmpresaByIdAsync(7), Times.Once);
        Assert.Equal("Empresa para deleção náo foi encontrada!", exception.Result.Message);
    }

    [Fact]
    [Trait(nameof(IEmpresasServices.GetDashboard), "Sucesso")]
    public void GetDashboard_DeveRetornarOsDadosDoDashboard_QuandoExistirDadosCadastrados()
    {
        //Arrange

        empresasPersistenceMock
            .Setup(d => d.GetDashboard(1, true))
            .Returns(empresasFixture.ObterDashboardMock(1, true));

        //Act

        var dashboardConsultado = _empresasServices.GetDashboard(1, true);

        //Assert

        Assert.Equal(77, dashboardConsultado.CountEmpresas);
        Assert.IsType<DashboardEmpresa>(dashboardConsultado);
        empresasPersistenceMock.Verify(p => p.GetDashboard(1, true), Times.Once);
    }

    [Fact]
    [Trait(nameof(IEmpresasServices.GetDashboard), "Insucesso")]
    public void GetDashboard_NaoDeveRetornarOsDadosDoDashboard_QuandoNaoExistirDadosCadastrados()
    {
        //Arrange

        empresasPersistenceMock
            .Setup(d => d.GetDashboard(1, false))
            .Returns(empresasFixture.ObterDashboardMock(1, false));

        //Act

        var dashboardConsultado = _empresasServices.GetDashboard(1, false);

        //Assert

        Assert.Null(dashboardConsultado);
        empresasPersistenceMock.Verify(p => p.GetDashboard(1, false), Times.Once);
    }

}

