using OnPeople.Domain.Models.Metas;
using System.ComponentModel.DataAnnotations;

namespace OnPeople.Application.Dtos.Metas
{
    public class MetaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NomeMeta { get; set; }
        public string TipoMeta { get; set; }
        public string Descricao { get; set; }
        public Boolean MetaCumprida { get; set; }
        public Boolean MetaAprovada { get; set; }
        public DateTime InicioPlanejado { get; set; }
        public DateTime FumPlanejado { get; set; }
        public int DiasPlanejado { get; set; }
        public DateTime InicioOficial { get; set; }
        public DateTime FimOficial { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int EmpresaId { get; set; }
    }
}