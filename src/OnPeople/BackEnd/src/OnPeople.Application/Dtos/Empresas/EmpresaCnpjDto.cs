using System.ComponentModel.DataAnnotations;
using OnPeople.Application.Dtos.Departamentos;
using OnPeople.Domain.Models.Users;

namespace OnPeople.Application.Dtos.Empresas
{
    public class EmpresaCnpjDto
    {
        public string cnpj_raiz { get; set; }
        public string razao_social { get; set; }
        public string capital_social { get; set; }
        public string responsavel_federativo { get; set; }
        public string atualizado_em { get; set; }
        public Porte porte { get; set; }
        public Natureza_Juridica natureza_juridica { get; set; }
        public string simples { get; set; }
        public Estabelecimento estabelecimento { get; set; }
    }

    public class Porte {
        public string id { get; set; }
        public string descricao { get; set; }
    }

    public class Natureza_Juridica {
        public string id { get; set; }
        public string descricao { get; set; }
    }

    public class Estabelecimento {
        public string cnpj { get; set; }
        public string tipo { get; set; }
        public string nome_fantasia { get; set; }
        public string situacao_cadastral { get; set; }
        public string data_situacao_cadastral { get; set; }
        public string data_inicio_atividade { get; set; }
        public string tipo_logradouro { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string ddd1 { get; set; }
        public string tekefine1 { get; set; }
        public string dd2 { get; set; }
        public string telefone2 { get; set; }
        public string ddd_fax { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public Atividade_Principal  atividade_principal { get; set; }
        public Pais pais { get; set; }
        public Estado estado { get; set; }
        public Cidade cidade { get; set; }
//        public IEnumerable<Inscricoes_Estaduais> inscricoes_estaduais { get; set; }
    }

    public class Atividade_Principal {
        public string id { get; set; }
        public string descricao { get; set; }

    }
    
    public class Pais {
        public string id { get; set; }
        public string iso2 { get; set; }
        public string iso3 { get; set; }
        public string nome { get; set; }

    }

    public class Estado {
        public int id { get; set; }
        public string nome { get; set; }
        public string sigla { get; set; }
        public int igbe_id { get; set; }
    }

        public class Cidade {
        public int id { get; set; }
        public string nome { get; set; }
        public int ibge_id { get; set; }
        public string siafi_id { get; set; }
    }

    public class Inscricoes_Estaduais {
        public string  inscricao_estadual { get; set; }
        public string Ativo { get; set; }
        public Estado estado { get; set; }
    }
}