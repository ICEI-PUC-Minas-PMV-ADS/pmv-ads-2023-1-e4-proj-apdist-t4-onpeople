using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnPeople.API.Extensions.Users;
using OnPeople.Application.Services.Contracts.Users;
using OnPeople.Application.Services.Contracts.Empresas;

namespace OnPeople.API.Controllers.Uploads
{
    [Authorize]
    [Route("api/[controller]")]
    public class UploadsController : Controller
    {
        private readonly IEmpresasServices _empresasServices;
        private readonly IUploads _uploads;
        private readonly IUsersServices _usersServices;
        private readonly string _destino = "Logos";
        public UploadsController(
            IEmpresasServices empresasServices,
            IUploads uploads,
            IUsersServices usersServices)
        {
            _empresasServices = empresasServices;
            _uploads = uploads;
            _usersServices = usersServices;
        }

        [HttpPost("upload-logo-empresa/{empresaId}")]
        public async Task<IActionResult> UploadLogoEmpresa(int empresaId)
        {
            try
            {
                var user = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

                var empresa = await _empresasServices.GetEmpresaByIdAsync(user.Id, user.Master, empresaId);

                if (empresa == null) return NoContent();

                var file = Request.Form.Files[0];

                if (file.Length > 0) {
                    _uploads.DeleteImageUpload(user.Id, user.Master, empresa.Logotipo, _destino);
                    empresa.Logotipo = await _uploads.SaveImageUpload(user.Id, user.Master, file, _destino);
                }

                return Ok(await _empresasServices.UpdateEmpresas(user.Id, user.Master, empresaId, empresa));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao realizar uplioda de logo da empresa. Erro: {e.Message}");
            }
        }   
    }
}