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
        private readonly IUploadService _uploads;
        private readonly IUsersServices _usersServices;
        private readonly string _destinoLogo = "Logos";
        private readonly string _destinoFoto = "Fotos";
        public UploadsController(
            IEmpresasServices empresasServices,
            IUploadService uploadService,
            IUsersServices usersServices)
        {
            _empresasServices = empresasServices;
            _uploads = uploadService;
            _usersServices = usersServices;
        }

        [HttpPost("upload-logo-company/{empresaId}")]
        public async Task<IActionResult> UploadLogoEmpresa(int empresaId)
        {
            try
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                var user = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

                var empresa = await _empresasServices.GetEmpresaByIdAsync(empresaId);

                if (empresa == null) return NoContent();

                var file = Request.Form.Files[0];

                if (file.Length > 0) {
                    _uploads.DeleteImageUpload(user.Id, user.Master, empresa.Logotipo, _destinoLogo);
                    empresa.Logotipo = await _uploads.SaveImageUpload(user.Id, user.Master, file, _destinoLogo);
                }

                return Ok(await _empresasServices.UpdateEmpresa(empresaId, empresa));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao realizar upload de logo da empresa. Erro: {e.Message}");
            }
        }   

        [HttpPost("upload-user-photo")]
        public async Task<IActionResult> UploadFotoUSer()
        {
            try
            {
                var user = await _usersServices.GetVisaoByUserNameAsync(User.GetUserNameClaim());

                if (user == null) return NoContent();

                var file = Request.Form.Files[0];
                Console.Write(file);

                if (file.Length > 0) {
                    _uploads.DeleteImageUpload(user.Id, user.Master, user.Foto, _destinoFoto);
                    user.Foto = await _uploads.SaveImageUpload(user.Id, user.Master, file, _destinoFoto);
                }

                return Ok(await _usersServices.UpdateUserVisaoAsync( user));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao realizar upload de fotos. Erro: {e.Message}");
            }
        }
    }
}
