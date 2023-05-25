using Bogus;
using OnPeople.Application.Dtos.Cargos;
using OnPeople.Domain.Models.Cargos;

namespace OnPeople.Tests.Cargos
{
    internal class CargosFixture
    {
        public IEnumerable<Cargo> ObterCargosMock()
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

        public IEnumerable<Cargo> ObterListaVaziaDeCargosMock()
        {
            return new List<Cargo> { };
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
