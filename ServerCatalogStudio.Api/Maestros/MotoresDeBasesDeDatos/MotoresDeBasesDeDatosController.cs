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

namespace ServerCatalogStudio.Api.Maestros.MotoresDeBasesDeDatos
{
    [Produces("application/json")]
    [Route("Maestros/Motores-Bdd")]
    [Authorize]
    public class MotoresDeBasesDeDatosController : Controller
    {
        private readonly CatalogoContext _context;
        private Payload _payload = new Payload();
        public MotoresDeBasesDeDatosController(CatalogoContext context)
        {
            _context = context;
        }

        // GET: api/MotoresDeBasesDeDatos
        [HttpGet]
        public IEnumerable<MotorBaseDeDatos> GetMotoresDeBasesDeDatos()
        {
            return _context.MotoresDeBasesDeDatos.Where(x => x.Activo);
        }

        // GET: api/MotoresDeBasesDeDatos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMotorBaseDeDatos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var MotorBaseDeDatos = await _context.MotoresDeBasesDeDatos.SingleOrDefaultAsync(m => m.Id == id);

            if (MotorBaseDeDatos == null)
            {
                return NotFound();
            }

            return Ok(MotorBaseDeDatos);
        }

        // PUT: api/MotoresDeBasesDeDatos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotorBaseDeDatos([FromRoute] int id, [FromBody] MotorBaseDeDatos MotorBaseDeDatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != MotorBaseDeDatos.Id)
            {
                return BadRequest();
            }

            _context.Entry(MotorBaseDeDatos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotorBaseDeDatosExists(id))
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


        // POST: api/MotoresDeBasesDeDatos
        [HttpPost]
        public async Task<IActionResult> PostMotorBaseDeDatos([FromBody] MotorBaseDeDatos MotorBaseDeDatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (EsRegistrado(MotorBaseDeDatos.Descripcion))
            {
                ModelState.AddModelError("Descripcion", "El sistema operativo ya se encuentra registrado.");
                return BadRequest(ModelState);
            }
            MotorBaseDeDatos.Activo = true;
            MotorBaseDeDatos.Descripcion = MotorBaseDeDatos.Descripcion.Trim();
            MotorBaseDeDatos.UsuarioAgregaId = _payload.Id;

            _context.MotoresDeBasesDeDatos.Add(MotorBaseDeDatos);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMotorBaseDeDatos", new { id = MotorBaseDeDatos.Id }, MotorBaseDeDatos);
        }

        bool EsRegistrado(string MotorBaseDeDatos)
        {
            MotorBaseDeDatos = MotorBaseDeDatos.Trim();
            return _context.MotoresDeBasesDeDatos.Any(s => s.Descripcion.ToLower() == MotorBaseDeDatos.ToLower() && s.Activo);
        }

        // DELETE: api/MotoresDeBasesDeDatos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotorBaseDeDatos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var MotorBaseDeDatos = await _context.MotoresDeBasesDeDatos.SingleOrDefaultAsync(m => m.Id == id);
            if (MotorBaseDeDatos == null)
            {
                return NotFound();
            }
            MotorBaseDeDatos.Activo = false;
            await _context.SaveChangesAsync();

            return Ok(MotorBaseDeDatos);
        }

        private bool MotorBaseDeDatosExists(int id)
        {
            return _context.MotoresDeBasesDeDatos.Any(e => e.Id == id);
        }
    }
}