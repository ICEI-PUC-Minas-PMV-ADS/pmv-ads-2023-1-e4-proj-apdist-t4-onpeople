using Bogus;
using OnPeople.Application.Dtos.Departamentos;
using OnPeople.Domain.Models.Departamentos;

namespace OnPeople.Tests.Departamentos
{
    internal class CargosFixture
    {
        public IEnumerable<Departamento> ObterDepartamentosMock()
        {
            return new List<Departamento>
            {
                new Departamento
                {
                        Id = 1,
                        NomeDepartamento = new Faker().Commerce.Department(),
                        Sigla = new Faker().Name.Prefix(),
                        DiretorId = 1,
                        GerenteId = 1,
                        SupervisorId = 1,
                        DataCriacao = "2023-05-18",
                        Ativo = true,
                        EmpresaId = 1
                },
                new Departamento
                {
                        Id = 2,
                        NomeDepartamento = new Faker().Commerce.Department(),
                        Sigla = new Faker().Name.Suffix(),
                        DiretorId = 1,
                        GerenteId = 1,
                        SupervisorId = 1,
                        DataCriacao = "2023-05-21",
                        Ativo = true,
                        EmpresaId = 2
                }
            };
        }

        public Departamento ObterApenasUmDepartamentoMock(int departamentoId)
        {
            if (departamentoId == 7)
            {
                return
                new Departamento
                {
                    Id = 7,
                    NomeDepartamento = new Faker().Commerce.Department(),
                    Sigla = new Faker().Name.Prefix(),
                    DiretorId = 1,
                    GerenteId = 1,
                    SupervisorId = 1,
                    DataCriacao = "2023-05-18",
                    Ativo = true,
                    EmpresaId = 3
                };
            }

            return null;

        }

        public DepartamentoDto ObterApenasUmDepartamentoDtoMock(int departamentoId)
        {
            if (departamentoId == 7)
            {
                return
                new DepartamentoDto
                {
                    Id = 7,
                    NomeDepartamento = new Faker().Commerce.Department(),
                    Sigla = new Faker().Name.Prefix(),
                    DiretorId = 1,
                    GerenteId = 1,
                    SupervisorId = 1,
                    DataCriacao = "2023-05-18",
                    Ativo = true,
                    EmpresaId = 3
                };
            }

            return null;

        }

        public IEnumerable<Departamento> ObterListaVaziaDeDepartamentosMock()
        {
            return new List<Departamento> { };
        }

        public Departamento CriarDepartamentoValidoMock()
        {
            return
            new Departamento
            {
                Id = 4,
                NomeDepartamento = "DepartamentoValido",
                Sigla = "DEPVAL",
                DiretorId = 1,
                GerenteId = 1,
                SupervisorId = 1,
                DataCriacao = "2023-05-22",
                Ativo = true,
                EmpresaId = 4
            };

        }
        public DepartamentoDto CriarDepartamentoValidoDtoMock()
        {
            return
            new DepartamentoDto
            {
                Id = 4,
                NomeDepartamento = "DepartamentoValido",
                Sigla = "DEPVAL",
                DiretorId = 1,
                GerenteId = 1,
                SupervisorId = 1,
                DataCriacao = "2023-05-22",
                Ativo = true,
                EmpresaId = 4
            };

        }

        public Departamento ObterDepartamentoCriadoMock(int departamentoId)
        {
            if (departamentoId == 4)
            {
                return
               new Departamento
               {
                   Id = 4,
                   NomeDepartamento = "DepartamentoValido",
                   Sigla = "DEPVAL",
                   DiretorId = 1,
                   GerenteId = 1,
                   SupervisorId = 1,
                   DataCriacao = "2023-05-22",
                   Ativo = true,
                   EmpresaId = 4
               };
            }

            return null;

        }

        public Departamento CriarDepartamentoInvalidoMock()
        {
            return
            new Departamento
            {
                Id = 4,
                NomeDepartamento = null,
                Sigla = null,
                DiretorId = 1,
                GerenteId = 1,
                SupervisorId = 1,
                DataCriacao = "2023-05-22",
                Ativo = true,
                EmpresaId = 4
            };

        }
        public DepartamentoDto CriarDepartamentoInvalidoDtoMock()
        {
            return
            new DepartamentoDto
            {
                Id = 4,
                NomeDepartamento = null,
                Sigla = null,
                DiretorId = 1,
                GerenteId = 1,
                SupervisorId = 1,
                DataCriacao = "2023-05-22",
                Ativo = true,
                EmpresaId = 4
            };

        }

        public Departamento ObterDepartamentAlteradoMock()
        {
            return
            new Departamento
            {
                Id = 4,
                NomeDepartamento = "DepartamentoAlterado",
                Sigla = "DEPALT",
                DiretorId = 2,
                GerenteId = 2,
                SupervisorId = 2,
                DataCriacao = "2023-05-22",
                Ativo = false,
                EmpresaId = 7
            };

        }
    }
}
