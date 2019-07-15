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
    public class DetallefacturaController : ControllerBase
    {
        private readonly MorenitaContext _context;

        public DetallefacturaController(MorenitaContext context)
        {
            _context = context;

            if (_context.Detallefacturas.Count() == 0)
            {
                _context.Detallefacturas.Add(new Detallefactura { DETALLE_ID = "1", DETALLE_CANTIDAD =5,DETALLE_PRECIO_VENTA =3000,DETALLE_FECHA_DET ="Benjumea",DETALLE_SUBTOTAL=40000, PRODUCTO_ID= "1",  MAESTRO_ID= "1"});
                _context.Detallefacturas.Add(new Detallefactura { DETALLE_ID = "2", DETALLE_CANTIDAD =5,DETALLE_PRECIO_VENTA =3000,DETALLE_FECHA_DET ="Benjumea",DETALLE_SUBTOTAL=40000,PRODUCTO_ID = "2",MAESTRO_ID = "2"});
                _context.SaveChanges();
            }
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Detallefactura>> PostTaskItem(Detallefactura item)
        {
            _context.Detallefacturas.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTaskItem), new { id = item.DETALLE_ID }, item);
        }
        // PUT: api/Task/5
        [HttpPut("{detalle_id}")]
        public async Task<IActionResult> PutTaskItem(string id, Detallefactura item)
        {
            if (id != item.DETALLE_ID)
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
        public async Task<ActionResult<IEnumerable<Detallefactura>>> GetTaskItems()
        {
            return await _context.Detallefacturas.ToListAsync();
        }

        // GET: api/Task/5
        [HttpGet("{detalle_id}")]
        public async Task<ActionResult<Detallefactura>> GetTaskItem(string id)
        {
            var taskItem = await _context.Detallefacturas.FindAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return taskItem;
        }

        // DELETE: api/Todo/5
        [HttpDelete("{detalle_id}")]
        public async Task<IActionResult> DeleteTaskItem(string id)
        {
            var TaskItem = await _context.Detallefacturas.FindAsync(id);

            if (TaskItem == null)
            {
                return NotFound();
            }

            _context.Detallefacturas.Remove(TaskItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
