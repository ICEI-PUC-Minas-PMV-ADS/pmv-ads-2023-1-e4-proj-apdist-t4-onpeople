using Bogus;
using OnPeople.Application.Dtos.Empresas;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;

namespace OnPeople.Tests.Departamentos
{
    internal class EmpresasFixture
    {
        public PageList<Empresa> ObterEmpresasMock()
        {
            return new PageList<Empresa>
            {
                new Empresa
                {
                        Id = 1,
                        Cnpj = new Faker().Random.Number(14).ToString(),
                        RazaoSocial = new Faker().Company.CompanyName(),
                        PorteEmpresa = "Médio",
                        NaturezaJuridica = "Sociedade por Ações",
                        OptanteSimples = "N",
                        Filial = false,
                        NomeFantasia = new Faker().Company.CompanyName(),
                        Ativa = true,
                        SiglaEmpresa = new Faker().Company.CompanySuffix(),
                        DataCadastro = new Faker().Date.Past().ToString(),
                        PadraoEmail = new Faker().Internet.Email()
                },
                new Empresa
                {
                        Id = 2,
                        Cnpj = new Faker().Random.Number(14).ToString(),
                        RazaoSocial = new Faker().Company.CompanyName(),
                        PorteEmpresa = "Grande",
                        NaturezaJuridica = "Sociedade Limitada",
                        OptanteSimples = "N",
                        Filial = true,
                        NomeFantasia = new Faker().Company.CompanyName(),
                        Ativa = true,
                        SiglaEmpresa = new Faker().Company.CompanySuffix(),
                        DataCadastro = new Faker().Date.Past().ToString(),
                        PadraoEmail = new Faker().Internet.Email()
                }
            };
        }

        public Empresa ObterApenasUmaEmpresaMock(int empresaId)
        {
            if (empresaId == 7)
            {
                return
                new Empresa
                {
                    Id = 7,
                    Cnpj = new Faker().Random.Number(14).ToString(),
                    RazaoSocial = new Faker().Company.CompanyName(),
                    PorteEmpresa = "Médio",
                    NaturezaJuridica = "Sociedade por Ações",
                    OptanteSimples = "N",
                    Filial = false,
                    NomeFantasia = new Faker().Company.CompanyName(),
                    Ativa = true,
                    SiglaEmpresa = new Faker().Company.CompanySuffix(),
                    DataCadastro = new Faker().Date.Past().ToString(),
                    PadraoEmail = new Faker().Internet.Email()
                };
            }

            return null;

        }

        public EmpresaDto ObterApenasUmaEmpresaDtoMock(int empresaId)
        {
            if (empresaId == 7)
            {
                return
                new EmpresaDto
                {
                    Id = 7,
                    Cnpj = new Faker().Random.Number(14).ToString(),
                    RazaoSocial = new Faker().Company.CompanyName(),
                    PorteEmpresa = "Médio",
                    NaturezaJuridica = "Sociedade por Ações",
                    OptanteSimples = "N",
                    Filial = false,
                    NomeFantasia = new Faker().Company.CompanyName(),
                    Ativa = true,
                    SiglaEmpresa = new Faker().Company.CompanySuffix(),
                    DataCadastro = new Faker().Date.Past().ToString(),
                    PadraoEmail = new Faker().Internet.Email()
                };
            }

            return null;

        }

        public PageList<Empresa> ObterListaVaziaDeEmpresasMock()
        {
            return new PageList<Empresa> { };
        }

        public Empresa CriarEmpresaValidaMock()
        {
            return
            new Empresa
            {
                Id = 4,
                Cnpj = "47873840000122",
                RazaoSocial = "RCSO CONSULTORIA LTDA",
                PorteEmpresa = "Médio",
                NaturezaJuridica = "Sociedade por Ações",
                OptanteSimples = "N",
                Filial = false,
                NomeFantasia = "RCSO",
                Ativa = true,
                SiglaEmpresa = "RCSO",
                DataCadastro = "2022-07-22",
                PadraoEmail = "rcso.com.br"
            };

        }
        public EmpresaDto CriarEmpresaValidaDtoMock()
        {
            return
            new EmpresaDto
            {
                Id = 4,
                Cnpj = "47873840000122",
                RazaoSocial = "RCSO CONSULTORIA LTDA",
                PorteEmpresa = "Médio",
                NaturezaJuridica = "Sociedade por Ações",
                OptanteSimples = "N",
                Filial = false,
                NomeFantasia = "RCSO",
                Ativa = true,
                SiglaEmpresa = "RCSO",
                DataCadastro = "2022-07-22",
                PadraoEmail = "rcso.com.br"
            };

        }

        public Empresa ObterEmpresaCriadaMock(int empresaId)
        {
            if (empresaId == 4)
            {
                return
               new Empresa
               {
                   Id = 4,
                   Cnpj = "47873840000122",
                   RazaoSocial = "RCSO CONSULTORIA LTDA",
                   PorteEmpresa = "Médio",
                   NaturezaJuridica = "Sociedade por Ações",
                   OptanteSimples = "N",
                   Filial = false,
                   NomeFantasia = "RCSO",
                   Ativa = true,
                   SiglaEmpresa = "RCSO",
                   DataCadastro = "2022-07-22",
                   PadraoEmail = "rcso.com.br"
               };
            }

            return null;

        }

        public Empresa CriarEmpresaInvalidaMock()
        {
            return
            new Empresa
            {
                Id = 4,
                Cnpj = null,
                RazaoSocial = null,
                PorteEmpresa = null,
                NaturezaJuridica = null,
                OptanteSimples = "N",
                Filial = false,
                NomeFantasia = "RCSO",
                Ativa = true,
                SiglaEmpresa = "RCSO",
                DataCadastro = "2022-07-22",
                PadraoEmail = "rcso.com.br"
            };

        }
        public EmpresaDto CriarEmpresaInvalidaDtoMock()
        {
            return
            new EmpresaDto
            {
                Id = 4,
                Cnpj = null,
                RazaoSocial = null,
                PorteEmpresa = null,
                NaturezaJuridica = null,
                OptanteSimples = "N",
                Filial = false,
                NomeFantasia = "RCSO",
                Ativa = true,
                SiglaEmpresa = "RCSO",
                DataCadastro = "2022-07-22",
                PadraoEmail = "rcso.com.br"
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

        public DashboardEmpresa ObterDashboardMock(int empresaId, Boolean master)
        {
            if (empresaId == 1 && master == true)
            {
                return
                new DashboardEmpresa
                {
                    CountEmpresas = 77
                };
            }

            return null;

        }
    }
}