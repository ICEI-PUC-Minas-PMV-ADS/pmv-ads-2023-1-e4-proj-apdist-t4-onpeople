using Bogus;
using OnPeople.Application.Dtos.Cargos;
using OnPeople.Domain.Models.Cargos;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Integration.Models.Pages.Config;

namespace OnPeople.Tests.Cargos
{
    internal class CargosFixture
    {
        public PageList<Cargo> ObterCargosMock()
        {
            return new PageList<Cargo>
            {
                new Cargo
                {
                        Id = 1,
                        NomeCargo = new Faker().Name.JobTitle(),
                        Ativo = true,
                        DataCriacao = "2023-05-18",
                        DataEncerramento = null,
                        DepartamentoId = 1,
                        EmpresaId = 1
                },
                new Cargo
                {
                        Id = 2,
                        NomeCargo = new Faker().Name.JobTitle(),
                        Ativo = true,
                        DataCriacao = "2023-05-21",
                        DataEncerramento = null,
                        DepartamentoId = 2,
                        EmpresaId = 2
                }
            };
        }

        public Cargo ObterApenasUmCargoMock(int cargoId)
        {
            if (cargoId == 7)
            {
                return
                new Cargo
                {
                    Id = 7,
                    NomeCargo = new Faker().Name.JobTitle(),
                    Ativo = true,
                    DataCriacao = "2023-05-21",
                    DataEncerramento = null,
                    DepartamentoId = 2,
                    EmpresaId = 2
                };
            }

            return null;

        }

        public CargoDto ObterApenasUmCargoDtoMock(int cargoId)
        {
            if (cargoId == 7)
            {
                return
                new CargoDto
                {
                    Id = 7,
                    NomeCargo = new Faker().Name.JobTitle(),
                    Ativo = true,
                    DataCriacao = "2023-05-21",
                    DataEncerramento = null,
                    DepartamentoId = 2,
                    EmpresaId = 2
                };
            }

            return null;
        }

        public PageList<Cargo> ObterListaVaziaDeCargosMock()
        {
            return new PageList<Cargo> { };
        }

        public Cargo CriarCargoValidoMock()
        {
            return
            new Cargo
            {
                Id = 4,
                NomeCargo = "CargoValido",
                Ativo = true,
                DataCriacao = "2023-05-21",
                DataEncerramento = null,
                DepartamentoId = 2,
                EmpresaId = 2
            };

        }

        public PageParameters ObterPageParametersMock()
        {
            return
                new PageParameters
                {
                    PageSize = 10,
                    PageNumber = 1
                };
        }

        public IEnumerable<Cargo> ObterCargosPorDepartamentoIdMock(int departamentoId)
        {
            if (departamentoId == 227)
            {
                return new List<Cargo>
                {
                        new Cargo
                        {
                                Id = 1,
                                NomeCargo = new Faker().Name.JobTitle(),
                                Ativo = true,
                                DataCriacao = "2023-05-18",
                                DataEncerramento = null,
                                DepartamentoId = 227,
                                EmpresaId = 7
                        },
                        new Cargo
                        {
                                Id = 2,
                                NomeCargo = new Faker().Name.JobTitle(),
                                Ativo = true,
                                DataCriacao = "2023-05-21",
                                DataEncerramento = null,
                                DepartamentoId = 227,
                                EmpresaId = 7
                        },
                        new Cargo
                        {
                                Id = 3,
                                NomeCargo = new Faker().Name.JobTitle(),
                                Ativo = true,
                                DataCriacao = "2021-07-22",
                                DataEncerramento = null,
                                DepartamentoId = 227,
                                EmpresaId = 7
                        }
                };
            };

            return null;

        }

        public CargoDto CriarCargoValidoDtoMock()
        {
            return
            new CargoDto
            {
                Id = 4,
                NomeCargo = "CargoValido",
                Ativo = true,
                DataCriacao = "2023-05-21",
                DataEncerramento = null,
                DepartamentoId = 2,
                EmpresaId = 2
            };

        }
        public Cargo ObterCargoCriadoMock(int cargoId)
        {
            if (cargoId == 4)
            {
                return
               new Cargo
               {
                   Id = 4,
                   NomeCargo = "CargoValido",
                   Ativo = true,
                   DataCriacao = "2023-05-21",
                   DataEncerramento = null,
                   DepartamentoId = 2,
                   EmpresaId = 2
               };
            }

            return null;

        }

        public Cargo CriarCargoInvalidoMock()
        {
            return
            new Cargo
            {
                Id = 4,
                NomeCargo = null,
                Ativo = true,
                DataCriacao = "2023-05-21",
                DataEncerramento = null,
                DepartamentoId = 2,
                EmpresaId = 2
            };

        }
        public CargoDto CriarCargoInvalidoDtoMock()
        {
            return
            new CargoDto
            {
                Id = 4,
                NomeCargo = null,
                Ativo = true,
                DataCriacao = "2023-05-21",
                DataEncerramento = null,
                DepartamentoId = 2,
                EmpresaId = 2
            };

        }
    }
}
