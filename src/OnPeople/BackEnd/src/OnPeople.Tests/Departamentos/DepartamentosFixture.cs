using Bogus;
using OnPeople.Application.Dtos.Departamentos;
using OnPeople.Domain.Models.Departamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
