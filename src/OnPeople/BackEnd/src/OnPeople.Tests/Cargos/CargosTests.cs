using Xunit;
using OnPeople.Application.Services.Contracts.Cargos;
using OnPeople.Application.Services.Implementations.Cargos;
using Moq;
using AutoMapper;
using OnPeople.Persistence.Interfaces.Contracts.Cargos;
using OnPeople.Persistence.Interfaces.Contracts.Shared;
using OnPeople.Domain.Models.Cargos;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Application.Dtos.Cargos;

namespace OnPeople.Tests.Cargos;

public class CargosServicesTests
{
    public readonly CargosServices _cargosServices;
    private readonly Mock<ISharedPersistence> sharedPersistenceMock;
    private readonly Mock<ICargosPersistence> cargosPersistenceMock;
    private readonly Mock<IMapper> mapperMock;
    private readonly CargosFixture cargosFixture;


    public CargosServicesTests()
    {
        sharedPersistenceMock = new Mock<ISharedPersistence>();
        cargosPersistenceMock = new Mock<ICargosPersistence>();
        mapperMock = new Mock<IMapper>();
        cargosFixture = new CargosFixture();


        _cargosServices = new CargosServices(
            sharedPersistenceMock.Object,
            cargosPersistenceMock.Object,
            mapperMock.Object
        );

    }

    [Fact]
    [Trait(nameof(ICargosServices.GetAllCargosAsync), "Sucesso")]
    public async Task GetAllCargosAsync_DeveRetornarAListaDeCargosCadastrados_QuandoExistirCargosCadastrados()
    {
        //Arrange

        cargosPersistenceMock
            .Setup(d => d.GetAllCargosAsync())
            .ReturnsAsync(cargosFixture.ObterCargosMock());


        mapperMock
            .Setup(x => x.Map<PageList<CargoDto>>(It.IsAny<IEnumerable<Cargo>>()))
            .Returns((List<Cargo> src) => new PageList<CargoDto>
            {
                new CargoDto
                {
                    Id = src[0].Id,
                    NomeCargo = src[0].NomeCargo,
                    Ativo = src[0].Ativo,
                    DataCriacao = src[0].DataCriacao,
                    DataEncerramento = src[0].DataEncerramento,
                    DepartamentoId = src[0].DepartamentoId,
                    EmpresaId = src[0].EmpresaId
                },
                new CargoDto
                {
                    Id = src[1].Id,
                    NomeCargo = src[1].NomeCargo,
                    Ativo = src[1].Ativo,
                    DataCriacao = src[1].DataCriacao,
                    DataEncerramento = src[1].DataEncerramento,
                    DepartamentoId = src[1].DepartamentoId,
                    EmpresaId = src[1].EmpresaId
                }
            });

        //Act

        var cargosConsultados = await _cargosServices.GetAllCargosAsync();

        //Assert

        Assert.True(cargosConsultados.Count.Equals(2));
        Assert.IsType<PageList<CargoDto>>(cargosConsultados);
        cargosPersistenceMock.Verify(p => p.GetAllCargosAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(ICargosServices.GetAllCargosAsync), "Insucesso")]
    public async Task GetAllCargosAsync_DeveRetornarUmaListaVazia_QuandoNaoExistirCargosCadastrados()
    {
        //Arrange

        cargosPersistenceMock
            .Setup(d => d.GetAllCargosAsync())
            .ReturnsAsync(cargosFixture.ObterListaVaziaDeCargosMock());


        mapperMock
            .Setup(x => x.Map<PageList<CargoDto>>(It.IsAny<IEnumerable<Cargo>>()))
            .Returns((List<Cargo> src) => new PageList<CargoDto>
            { });

        //Act

        var cargosConsultados = await _cargosServices.GetAllCargosAsync();

        //Assert

        Assert.False(cargosConsultados.Count > 0);
        cargosPersistenceMock.Verify(p => p.GetAllCargosAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(ICargosServices.GetCargoByIdAsync), "Sucesso")]
    public async Task GetCargoByIdAsync_DeveRetornarOsDadosDoCargo_QuandoOIdInformadoForValido()
    {
        //Arrange

        cargosPersistenceMock
            .Setup(d => d.GetCargoByIdAsync(7))
            .Callback<int>(Id => Assert.Equal(7, Id))
            .ReturnsAsync(cargosFixture.ObterApenasUmCargoMock(7));


        mapperMock
            .Setup(x => x.Map<CargoDto>(It.IsAny<Cargo>()))
            .Returns((Cargo src) => new CargoDto
            {
                Id = src.Id,
                NomeCargo = src.NomeCargo,
                Ativo = src.Ativo,
                DataCriacao = src.DataCriacao,
                DataEncerramento = src.DataEncerramento,
                DepartamentoId = src.DepartamentoId,
                EmpresaId = src.EmpresaId
            });

        //Act

        var cargoConsultado = await _cargosServices.GetCargoByIdAsync(7);

        //Assert

        Assert.Equal(7, cargoConsultado.Id);
        Assert.IsType<CargoDto>(cargoConsultado);
        cargosPersistenceMock.Verify(p => p.GetCargoByIdAsync(7), Times.Once);
    }

    [Fact]
    [Trait(nameof(ICargosServices.GetCargoByIdAsync), "Insucesso")]
    public async Task GetCargoByIdAsync_NaoDeveRetornarOsDadosDoCargo_QuandoOIdInformadoForInvalido()
    {
        //Arrange

        cargosPersistenceMock
            .Setup(d => d.GetCargoByIdAsync(100))
            .Callback<int>(Id => Assert.Equal(100, Id))
            .ReturnsAsync(cargosFixture.ObterApenasUmCargoMock(100));


        mapperMock
            .Setup(x => x.Map<CargoDto>(It.IsAny<Cargo>()))
            .Returns((Cargo src) => new CargoDto
            {
                Id = src.Id,
                NomeCargo = src.NomeCargo,
                Ativo = src.Ativo,
                DataCriacao = src.DataCriacao,
                DataEncerramento = src.DataEncerramento,
                DepartamentoId = src.DepartamentoId,
                EmpresaId = src.EmpresaId
            });

        //Act

        var cargoConsultado = await _cargosServices.GetCargoByIdAsync(100);

        //Assert

        Assert.Null(cargoConsultado);
        cargosPersistenceMock.Verify(p => p.GetCargoByIdAsync(100), Times.Once);

    }

    [Fact]
    [Trait(nameof(ICargosServices.GetCargosByDepartamentoIdAsync), "Sucesso")]
    public async Task GetCargosByDepartamentoIdAsync_DeveRetornarOsCargosDoDepartamento_QuandoODepartamentoPossuirCargosCadastrados()
    {
        //Arrange

        cargosPersistenceMock
            .Setup(d => d.GetCargosByDepartamentoIdAsync(227))
            .Callback<int>(Id => Assert.Equal(227, Id))
            .ReturnsAsync(cargosFixture.ObterCargosPorDepartamentoIdMock(227));

        mapperMock
            .Setup(x => x.Map<PageList<CargoDto>>(It.IsAny<IEnumerable<Cargo>>()))
            .Returns((List<Cargo> src) => new PageList<CargoDto>
            {
                new CargoDto
                {
                    Id = src[0].Id,
                    NomeCargo = src[0].NomeCargo,
                    Ativo = src[0].Ativo,
                    DataCriacao = src[0].DataCriacao,
                    DataEncerramento = src[0].DataEncerramento,
                    DepartamentoId = src[0].DepartamentoId,
                    EmpresaId = src[0].EmpresaId
                },
                new CargoDto
                {
                    Id = src[1].Id,
                    NomeCargo = src[1].NomeCargo,
                    Ativo = src[1].Ativo,
                    DataCriacao = src[1].DataCriacao,
                    DataEncerramento = src[1].DataEncerramento,
                    DepartamentoId = src[1].DepartamentoId,
                    EmpresaId = src[1].EmpresaId
                },
                new CargoDto
                {
                    Id = src[2].Id,
                    NomeCargo = src[2].NomeCargo,
                    Ativo = src[2].Ativo,
                    DataCriacao = src[2].DataCriacao,
                    DataEncerramento = src[2].DataEncerramento,
                    DepartamentoId = src[2].DepartamentoId,
                    EmpresaId = src[2].EmpresaId
                }
            });

        //Act

        var cargosConsultados = await _cargosServices.GetCargosByDepartamentoIdAsync(227);

        //Assert

        Assert.True(cargosConsultados.Count.Equals(3));
        Assert.IsType<PageList<CargoDto>>(cargosConsultados);
        cargosPersistenceMock.Verify(p => p.GetCargosByDepartamentoIdAsync(227), Times.Once);
    }

    [Fact]
    [Trait(nameof(ICargosServices.GetCargosByDepartamentoIdAsync), "Insucesso")]
    public async Task GetCargosByDepartamentoIdAsync_NaoDeveRetornarOsCargosDoDepartamento_QuandoODepartamentoNaoPossuirCargosCadastrados()
    {
        //Arrange

        cargosPersistenceMock
            .Setup(d => d.GetCargosByDepartamentoIdAsync(228))
            .Callback<int>(Id => Assert.Equal(228, Id))
            .ReturnsAsync(cargosFixture.ObterCargosPorDepartamentoIdMock(228));

        //Act

        var cargosConsultados = await _cargosServices.GetCargosByDepartamentoIdAsync(228);

        //Assert

        Assert.Null(cargosConsultados);
        cargosPersistenceMock.Verify(p => p.GetCargosByDepartamentoIdAsync(228), Times.Once);
    }

    [Fact]
    [Trait(nameof(ICargosServices.CreateCargos), "Sucesso")]
    public async Task CreateCargos_DeveRealizarAInclusaoDoCargo_QuandoOsDadosForemValidos()
    {
        //Arrange

        var cargoDto = cargosFixture.CriarCargoValidoDtoMock();
        var cargo = cargosFixture.CriarCargoValidoMock();


        mapperMock
              .Setup(m => m.Map<Cargo>(It.IsAny<CargoDto>()))
              .Returns((CargoDto src) => new Cargo
              {
                  Id = src.Id,
                  NomeCargo = src.NomeCargo,
                  Ativo = src.Ativo,
                  DataCriacao = src.DataCriacao,
                  DataEncerramento = src.DataEncerramento,
                  DepartamentoId = src.DepartamentoId,
                  EmpresaId = src.EmpresaId
              });

        mapperMock
              .Setup(m => m.Map<CargoDto>(It.IsAny<Cargo>()))
              .Returns((Cargo source) => new CargoDto
              {
                  Id = source.Id,
                  NomeCargo = source.NomeCargo,
                  Ativo = source.Ativo,
                  DataCriacao = source.DataCriacao,
                  DataEncerramento = source.DataEncerramento,
                  DepartamentoId = source.DepartamentoId,
                  EmpresaId = source.EmpresaId
              });

        sharedPersistenceMock
            .Setup(c => c.Create<Cargo>(cargo))
            .Callback<Cargo>(cargo =>
            {
                Assert.Equal(4, cargo.Id);
                Assert.Equal("CargoValido", cargo.NomeCargo);
                Assert.True(cargo.Ativo);
                Assert.Equal("2023-05-21", cargo.DataCriacao);
                Assert.Equal(2, cargo.DepartamentoId);
                Assert.Equal(2, cargo.EmpresaId);
            });

        sharedPersistenceMock
            .Setup(s => s.SaveChangesAsync())
            .ReturnsAsync(true);

        cargosPersistenceMock
            .Setup(g => g.GetCargoByIdAsync(cargo.Id))
            .Callback<int>(Id => Assert.Equal(4, Id))
            .ReturnsAsync(cargosFixture.ObterCargoCriadoMock(cargo.Id));

        //Act

        var cargoCriado = await _cargosServices.CreateCargos(cargoDto);

        //Assert

        Assert.Equal(4, cargoCriado.Id);
        Assert.IsType<CargoDto>(cargoCriado);
        cargosPersistenceMock.Verify(p => p.GetCargoByIdAsync(4), Times.Once);
        sharedPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(ICargosServices.CreateCargos), "Insucesso")]
    public async Task CreateCargos_NaoDeveRealizarAInclusaoDoCargo_QuandoOsDadosForemInvalidos()
    {
        //Arrange

        var cargoDto = cargosFixture.CriarCargoValidoDtoMock();
        var cargo = cargosFixture.CriarCargoValidoMock();

        mapperMock
              .Setup(m => m.Map<Cargo>(It.IsAny<CargoDto>()))
              .Returns((CargoDto src) => new Cargo
              {
                  Id = src.Id,
                  NomeCargo = src.NomeCargo,
                  Ativo = src.Ativo,
                  DataCriacao = src.DataCriacao,
                  DataEncerramento = src.DataEncerramento,
                  DepartamentoId = src.DepartamentoId,
                  EmpresaId = src.EmpresaId
              });

        mapperMock
              .Setup(m => m.Map<CargoDto>(It.IsAny<Cargo>()))
              .Returns((Cargo source) => new CargoDto
              {
                  Id = source.Id,
                  NomeCargo = source.NomeCargo,
                  Ativo = source.Ativo,
                  DataCriacao = source.DataCriacao,
                  DataEncerramento = source.DataEncerramento,
                  DepartamentoId = source.DepartamentoId,
                  EmpresaId = source.EmpresaId
              });

        sharedPersistenceMock
            .Setup(c => c.Create<Cargo>(cargo));

        sharedPersistenceMock
            .Setup(s => s.SaveChangesAsync())
            .ReturnsAsync(false);

        //Act

        var cargoCriado = await _cargosServices.CreateCargos(cargoDto);

        //Assert

        Assert.Null(cargoCriado);
        sharedPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(ICargosServices.DeleteCargo), "Sucesso")]
    public async Task DeleteCargo_DeveRealizarAExclusaoDoCargo_QuandoOCargoExistir()
    {
        //Arrange

        var cargo = cargosFixture.ObterApenasUmCargoMock(7);

        cargosPersistenceMock
           .Setup(g => g.GetCargoByIdAsync(7))
           .ReturnsAsync(cargosFixture.ObterApenasUmCargoMock(7));

        sharedPersistenceMock
            .Setup(c => c.Delete<Cargo>(cargo));

        sharedPersistenceMock
            .Setup(s => s.SaveChangesAsync())
            .ReturnsAsync(true);

        //Act

        var cargoExcluido = await _cargosServices.DeleteCargo(cargo.Id);

        //Assert

        Assert.True(cargoExcluido);
        cargosPersistenceMock.Verify(p => p.GetCargoByIdAsync(7), Times.Once);
        sharedPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(ICargosServices.DeleteCargo), "Insucesso")]
    public async Task DeleteCargo_NaoDeveRealizarAExclusaoDoCargo_QuandoOCargoNaoExistir()
    {
        //Arrange

        var cargo = cargosFixture.ObterApenasUmCargoMock(7);

        cargosPersistenceMock
           .Setup(g => g.GetCargoByIdAsync(8))
           .ReturnsAsync(cargosFixture.ObterApenasUmCargoMock(8));

        sharedPersistenceMock
            .Setup(c => c.Delete<Cargo>(cargo));

        //Act

        var cargoExcluido = await _cargosServices.DeleteCargo(cargo.Id);

        //Assert

        Assert.False(cargoExcluido);
        cargosPersistenceMock.Verify(p => p.GetCargoByIdAsync(7), Times.Once);
    }

}

