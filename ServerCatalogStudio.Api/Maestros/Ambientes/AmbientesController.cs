using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerCatalogStudio.Api.Infraestructure;
using Microsoft.AspNetCore.Authorization;
using ServerCatalogStudio.Api.Auth;
using Microsoft.AspNetCore.Mvc.Filters;
using ServerCatalogStudio.Api.Auth.Models;

namespace ServerCatalogStudio.Api.Maestros.Ambientes
{
    [Produces("application/json")]
    [Route("Maestros/Ambientes")]
    [Authorize]
    public class AmbientesController : Controller
    {
        private readonly CatalogoContext _context;
        private Payload _payload = new Payload();
        public AmbientesController(CatalogoContext context)
        {
            _context = context;
        }

        // GET: api/Ambientes
        [HttpGet]
        public IEnumerable<Ambiente> GetAmbientes()
        {
            return _context.Ambientes.Where(x => x.Activo);
        }

        // GET: api/Ambientes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAmbiente([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Ambiente = await _context.Ambientes.SingleOrDefaultAsync(m => m.Id == id);

            if (Ambiente == null)
            {
                return NotFound();
            }

            return Ok(Ambiente);
        }

        // PUT: api/Ambientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmbiente([FromRoute] int id, [FromBody] Ambiente Ambiente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Ambiente.Id)
            {
                return BadRequest();
            }

            _context.Entry(Ambiente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmbienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _payload = HttpContext.GetPayload();
            base.OnActionExecuting(context);
        }


        // POST: api/Ambientes
        [HttpPost]
        public async Task<IActionResult> PostAmbiente([FromBody] Ambiente Ambiente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (EsRegistrado(Ambiente.Descripcion))
            {
                return BadRequest("Ya se encuentra registrado un ambiente con el mismo nombre.");
            }
            Ambiente.Activo = true;
            Ambiente.Descripcion = Ambiente.Descripcion.Trim();
            Ambiente.UsuarioAgregaId = _payload.Id;

            _context.Ambientes.Add(Ambiente);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAmbiente", new { id = Ambiente.Id }, Ambiente);
        }

        bool EsRegistrado(string Ambiente)
        {
            Ambiente = Ambiente.Trim();
            return _context.Ambientes.Any(s => s.Descripcion.ToLower() == Ambiente.ToLower() && s.Activo);
        }

        // DELETE: api/Ambientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmbiente([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Ambiente = await _context.Ambientes.SingleOrDefaultAsync(m => m.Id == id);
            if (Ambiente == null)
            {
                return NotFound();
            }
            Ambiente.Activo = false;
            await _context.SaveChangesAsync();

            return Ok(Ambiente);
        }

        private bool AmbienteExists(int id)
        {
            return _context.Ambientes.Any(e => e.Id == id);
        }
    }
}