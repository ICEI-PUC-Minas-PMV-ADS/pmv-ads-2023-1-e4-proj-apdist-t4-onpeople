using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnPeople.Domain.Models.Funcionarios;

namespace OnPeople.Domain.Models.Metas
{
    public class Meta
    {
        public int Id { get; set; }
        public string TipoMeta { get; set; }
        public string NomeMeta { get; set; }
        public string Descricao { get; set; }
        public Boolean MetaCumprida { get; set; }
        public Boolean MetaAprovada { get; set; }
        public string InicioPlanejado { get; set; }
        public string FumPlanejado { get; set; }
        public int DiasPlanejado { get; set; }
        public string InicioOficial { get; set; }
        public string FimOficial { get; set; }
        public int EmpresaId { get; set; }
        
        //public Empresa Empresas { get; set; }
        public IEnumerable<FuncionarioMeta> FuncionariosMetas { get; set; }
    }
}