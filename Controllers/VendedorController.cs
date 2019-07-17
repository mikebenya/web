using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskSharpHTTP.Models;

namespace TaskSharpHTTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly MorenitaContext _context;

        public VendedorController(MorenitaContext context)
        {
            _context = context;

            if (_context.Vendedores.Count() == 0)
            {
                _context.Vendedores.Add(new Vendedor { VENDEDOR_ID = "1", VENDEDOR_NOMBRE1_VEN ="Maicool ",VENDEDOR_NOMBRE2_VEN ="Yamith ",VENDEDOR_APELLIDO1_VEN ="Benjumea",VENDEDOR_APELLIDO2_VEN="Amaya",VENDEDOR_CALLE_VEN = "calle 29",VENDEDOR_CASA_VEN = "#44-29",VENDEDOR_BARRIO_VEN = "alamos",VENDEDOR_TELEFONO_VEN = "3003148827",VENDEDOR_USUARIO = "mikeBenya",VENDEDOR_CONTRASENA="1127",FacturaMaestros=null});
                _context.Vendedores.Add(new Vendedor { VENDEDOR_ID = "2", VENDEDOR_NOMBRE1_VEN ="Carlos ",VENDEDOR_NOMBRE2_VEN ="Yamith ",VENDEDOR_APELLIDO1_VEN ="Cotes",VENDEDOR_APELLIDO2_VEN="Amaya",VENDEDOR_CALLE_VEN = "calle 13",VENDEDOR_CASA_VEN = "#44-29",VENDEDOR_BARRIO_VEN = "alamos",VENDEDOR_TELEFONO_VEN = "3003148827",VENDEDOR_USUARIO = "carlosCotes",VENDEDOR_CONTRASENA="12345",FacturaMaestros=null});
                _context.SaveChanges();
            }
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Vendedor>> PostVendedor(Vendedor newVendedor)
        {
              var varProducto = await _context.Productos.FindAsync(newVendedor.VENDEDOR_ID) ;
            if (varProducto!=null)
            {
                return NotFound();
            }else{
            _context.Vendedores.Add(newVendedor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVendedor), new { id = newVendedor.VENDEDOR_ID }, newVendedor);
            }
        }
        // PUT: api/Task/5
        [HttpPut("{vendedor_id}")]
        public async Task<IActionResult> PutVendedor(string id, Vendedor item)
        {
            if (id != item.VENDEDOR_ID)
            {
                return BadRequest();
            }
            //var task = _context.TaskItems.FindAsync(id);

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedor>>> GetVendedores()
        {
            return await _context.Vendedores.ToListAsync();
        }

        // GET: api/Task/5
        [HttpGet("{vendedor_id}")]
        public async Task<ActionResult<Vendedor>> GetVendedor(string id)
        {
            var taskItem = await _context.Vendedores.FindAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return taskItem;
        }

        // DELETE: api/Todo/5
        [HttpDelete("{vendedor_id}")]
        public async Task<IActionResult> DeleteVendedor(string id)
        {
            var TaskItem = await _context.Vendedores.FindAsync(id);

            if (TaskItem == null)
            {
                return NotFound();
            }

            _context.Vendedores.Remove(TaskItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
