using Microsoft.AspNetCore.Mvc;
using OnPeople.Application.Services.Contracts.Empresas;

namespace OnPeople.API.Controllers.Uploads
{
    [Route("api/[controller]")]
    public class UploadsController : Controller
    {
        private readonly IEmpresasServices _empresasServices;
        private readonly IUploads _uploads;
        private readonly string _destino = "Logos";
        public UploadsController(IEmpresasServices empresasServices,
                            IUploads uploads)
        {
            _empresasServices = empresasServices;
            _uploads = uploads;
        }

        [HttpPost("upload-logo-empresa/{empresaId}")]
        public async Task<IActionResult> UploadLogoEmpresa(int empresaId)
        {
            try
            {
                var empresa = await _empresasServices.GetEmpresaByIdAsync(empresaId);

                if (empresa == null) return NoContent();

                var file = Request.Form.Files[0];

                if (file.Length > 0) {
                    _uploads.DeleteImageUpload(empresa.Logotipo, _destino);
                    empresa.Logotipo = await _uploads.SaveImageUpload(file, _destino);
                }

                return Ok(await _empresasServices.UpdateEmpresas(empresaId, empresa));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao realizar uplioda de logo da empresa. Erro: {e.Message}");
            }
        }   
    }
}