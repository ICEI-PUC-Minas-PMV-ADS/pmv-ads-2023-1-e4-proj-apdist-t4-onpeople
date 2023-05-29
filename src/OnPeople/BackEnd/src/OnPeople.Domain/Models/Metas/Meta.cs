using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class Meta
    {
        public int Id { get; set; }
        public string TipoMeta { get; set; }
        public string NomeMeta { get; set; }
        public string descricao { get; set; }
        public Boolean MetaCumprida { get; set; }
        public Boolean MetaAprovada { get; set; }
        public DateTime InicioPlanejado { get; set; }
        public DateTime FumPlanejado { get; set; }
        public int DiasPlanejado { get; set; }
        public DateTime InicioOficial { get; set; }
        public DateTime FimOficial { get; set; }
        public int EmpresaId { get; set; }
        
        //public Empresa Empresas { get; set; }
        //public IEnumerable<FuncionarioMeta> FuncionariosMetas { get; set; }
    }
}