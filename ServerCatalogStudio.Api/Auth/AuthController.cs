using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServerCatalogStudio.Api.Infraestructure;

namespace ServerCatalogStudio.Api.Auth
{
    [Produces("application/json")]
    [Route("Auth")]
    public class AuthController : Controller
    {
        private readonly TokenService _tokenService;
        private readonly CatalogoContext _catalogoContext;
        public AuthController(TokenService tokenService, CatalogoContext catalogoContext)
        {
            _tokenService = tokenService;
            _catalogoContext = catalogoContext;
        }


        [Route("")]
        [HttpPost]
        public IActionResult Autenticar([FromBody] Credenciales credenciales)
        {
            Usuario usuario;
            if (!SonCredencialesValidas(credenciales, out usuario))
            {
                return Unauthorized();
            }

            var token = new
            {
                token = _tokenService.GenerarToken(usuario)
            };

            return Ok(token);
        }

        bool SonCredencialesValidas(Credenciales credenciales, out Usuario usuario)
        {
            usuario = _catalogoContext.Usuarios
               .FirstOrDefault(u => u.Email == credenciales.Email);

            if (usuario == null ||
                string.IsNullOrWhiteSpace(credenciales.Clave) ||
                !usuario.Activo)
            {
                return false;
            }

            bool sonClavesIguales = usuario.Clave.IsEqual(credenciales.Clave.ToHash());
            return sonClavesIguales;
        }



    }
}