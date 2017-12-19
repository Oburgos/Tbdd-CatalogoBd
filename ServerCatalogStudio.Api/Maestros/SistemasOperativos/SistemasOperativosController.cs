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

namespace ServerCatalogStudio.Api.Maestros.SistemasOperativos
{
    [Produces("application/json")]
    [Route("Maestros/Sistemas-Operativos")]
    [Authorize]
    public class SistemasOperativosController : Controller
    {
        private readonly CatalogoContext _context;
        private Payload _payload = new Payload();
        public SistemasOperativosController(CatalogoContext context)
        {
            _context = context;
        }

        // GET: api/SistemasOperativos
        [HttpGet]
        public IEnumerable<SistemaOperativo> GetSistemasOperativos()
        {
            return _context.SistemasOperativos.Where(x => x.Activo);
        }

        // GET: api/SistemasOperativos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSistemaOperativo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sistemaOperativo = await _context.SistemasOperativos.SingleOrDefaultAsync(m => m.Id == id);

            if (sistemaOperativo == null)
            {
                return NotFound();
            }

            return Ok(sistemaOperativo);
        }

        // PUT: api/SistemasOperativos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSistemaOperativo([FromRoute] int id, [FromBody] SistemaOperativo sistemaOperativo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sistemaOperativo.Id)
            {
                return BadRequest();
            }

            _context.Entry(sistemaOperativo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SistemaOperativoExists(id))
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


        // POST: api/SistemasOperativos
        [HttpPost]
        public async Task<IActionResult> PostSistemaOperativo([FromBody] SistemaOperativo sistemaOperativo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (EsRegistrado(sistemaOperativo.Descripcion))
            {
                ModelState.AddModelError("Descripcion", "El sistema operativo ya se encuentra registrado.");
                return BadRequest(ModelState);
            }
            sistemaOperativo.Activo = true;
            sistemaOperativo.Descripcion = sistemaOperativo.Descripcion.Trim();
            sistemaOperativo.UsuarioAgregaId = _payload.Id;

            _context.SistemasOperativos.Add(sistemaOperativo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetSistemaOperativo", new { id = sistemaOperativo.Id }, sistemaOperativo);
        }

        bool EsRegistrado(string sistemaOperativo)
        {
            sistemaOperativo = sistemaOperativo.Trim();
            return _context.SistemasOperativos.Any(s => s.Descripcion.ToLower() == sistemaOperativo.ToLower() && s.Activo);
        }

        // DELETE: api/SistemasOperativos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSistemaOperativo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sistemaOperativo = await _context.SistemasOperativos.SingleOrDefaultAsync(m => m.Id == id);
            if (sistemaOperativo == null)
            {
                return NotFound();
            }
            sistemaOperativo.Activo = false;
            await _context.SaveChangesAsync();

            return Ok(sistemaOperativo);
        }

        private bool SistemaOperativoExists(int id)
        {
            return _context.SistemasOperativos.Any(e => e.Id == id);
        }
    }
}