using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerCatalogStudio.Api.Auth.Models;
using ServerCatalogStudio.Api.Infraestructure;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using ServerCatalogStudio.Api.Auth;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ServerCatalogStudio.Api.Servidores
{
    [Produces("application/json")]
    [Route("Servidores")]
    [Authorize]
    public class ServidoresController : Controller
    {
        private readonly CatalogoContext _context;
        private Payload _payload = new Payload();
        public ServidoresController(CatalogoContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _payload = HttpContext.GetPayload();
            base.OnActionExecuting(context);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostServidor([FromBody] Servidor servidor)
        {
            try
            {
                servidor.Activo = true;
                servidor.configuracion.UsuarioAgregaId = _payload.Id;
                servidor.Descripcion = servidor.Descripcion.Trim();
                servidor.UsuarioAgregaId = _payload.Id;
                _context.Servidores.Add(servidor);
                await _context.SaveChangesAsync();
                return Ok(servidor);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


        [HttpGet]
        [Route("")]
        public IActionResult GetServidores()
        {
            var servidores = (from s in _context.Servidores
                              where s.Activo
                              select new
                              {
                                  s.Id,
                                  s.Descripcion,
                                  Ambiente = s.Ambiente.Descripcion,
                                  SistemaOperativo = s.SistemaOperativo.Descripcion,
                                  s.Almacenamiento,
                                  s.Ram,
                                  s.Cores
                              }).ToList();
            return Ok(servidores);
        }


    }
}