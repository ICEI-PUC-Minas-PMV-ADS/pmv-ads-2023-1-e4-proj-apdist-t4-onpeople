using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnPeople.Application.Dtos.Empresas
{
    public class AtualizarEmpresaAtivaDto
    {
        public int Id { get; set; }
        public Boolean Ativa { get; set; }
    }
}