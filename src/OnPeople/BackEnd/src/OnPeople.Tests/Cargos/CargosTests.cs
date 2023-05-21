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
using OnPeople.Domain.Models.Empresas;
using System;


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

        Assert.True(cargosConsultados.Count > 0);
        Assert.IsType<PageList<CargoDto>>(cargosConsultados);
        cargosPersistenceMock.Verify(p => p.GetAllCargosAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(ICargosServices.GetAllCargosAsync), "Insucesso")]
    public async Task GetAllCargosAsync_DeveRetornarUmaListaVazia_QuandoNãoExistirCargosCadastrados()
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

        var departamentosConsultados = await _cargosServices.GetAllCargosAsync();

        //Assert

        Assert.False(departamentosConsultados.Count > 0);
        cargosPersistenceMock.Verify(p => p.GetAllCargosAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(ICargosServices.GetCargoByIdAsync), "Sucesso")]
    public async Task GetCargoByIdAsync_DeveRetornarOsDadosDoCargo_QuandoOIdInformadoForValido()
    {
        //Arrange

        cargosPersistenceMock
            .Setup(d => d.GetCargoByIdAsync(7))
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
    public async Task GetCargoByIdAsync_NãoDeveRetornarOsDadosDoCargo_QuandoOIdInformadoForInValido()
    {
        //Arrange

        cargosPersistenceMock
            .Setup(d => d.GetCargoByIdAsync(100))
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
    [Trait(nameof(ICargosServices.CreateCargos), "Sucesso")]
    public async Task CreateCargos_DeveRealizarAInclusaoDoCargo_QuandoOsDadosForemValidos()
    {
        //Arrange

        var cargoDto = cargosFixture.CriarCargoValidoDtoMock();
        var cargo = cargosFixture.CriarCargoValidoMock();


        mapperMock
            .Setup(x => x.Map<Cargo>(cargoDto))
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

        sharedPersistenceMock
            .Setup(c => c.Create<Cargo>(cargo));

        sharedPersistenceMock
            .Setup(s => s.SaveChangesAsync())
            .ReturnsAsync(true);



        cargosPersistenceMock
            .Setup(g => g.GetCargoByIdAsync(4))
            .ReturnsAsync(cargosFixture.ObterCargoCriadoMock(4));

        mapperMock
          .Setup(m => m.Map<CargoDto>(cargo))
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


        //Act

        var cargoCriado = await _cargosServices.CreateCargos(cargoDto);

        //Assert

        Assert.Equal(4, cargoCriado.Id);
        Assert.IsType<CargoDto>(cargoCriado);
        cargosPersistenceMock.Verify(p => p.GetCargoByIdAsync(4), Times.Once);
        sharedPersistenceMock.Verify(s => s.Create<CargoDto>(cargoDto), Times.Once);
        sharedPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

}








