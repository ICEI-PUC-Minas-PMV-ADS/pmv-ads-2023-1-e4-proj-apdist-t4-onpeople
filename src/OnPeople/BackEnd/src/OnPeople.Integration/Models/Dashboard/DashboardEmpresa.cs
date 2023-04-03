using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnPeople.Integration.Models.Links;

namespace OnPeople.Integration.Models.Dashboard
{
    public class DashboardEmpresa : LinksHATEOS
    {
        public int CountEmpresas { get; set; }
        public int CountEmpresasAtivas { get; set; }
        public int CountFiliais { get; set; }
        public int CountFiliaisAtivas{ get; set; }
    }
}