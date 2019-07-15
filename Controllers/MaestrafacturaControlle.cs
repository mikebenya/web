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
    public class MaestrafacturaController : ControllerBase
    {
        private readonly MorenitaContext _context;

        public MaestrafacturaController(MorenitaContext context)
        {
            _context = context;

            if (_context.Maestrafacturas.Count() == 0)
            {
                _context.Maestrafacturas.Add(new Maestrafactura { MAESTRO_ID = "1", MAESTRO_FECHA_FAC ="13/03/2019",MAESTRO_TOTAL =3000,CLIENTE_ID ="1",VENDEDOR_ID="1"});
                _context.Maestrafacturas.Add(new Maestrafactura { MAESTRO_ID = "2", MAESTRO_FECHA_FAC ="13/03/2019",MAESTRO_TOTAL =3000,CLIENTE_ID ="2",VENDEDOR_ID="2"});
                _context.SaveChanges();
            }
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Maestrafactura>> PostTaskItem(Maestrafactura item)
        {
            _context.Maestrafacturas.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTaskItem), new { id = item.MAESTRO_ID }, item);
        }
        // PUT: api/Task/5
        [HttpPut("{maestro_id}")]
        public async Task<IActionResult> PutTaskItem(string id, Maestrafactura item)
        {
            if (id != item.MAESTRO_ID)
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
        public async Task<ActionResult<IEnumerable<Maestrafactura>>> GetTaskItems()
        {
            return await _context.Maestrafacturas.ToListAsync();
        }

        // GET: api/Task/5
        [HttpGet("{maestro_id}")]
        public async Task<ActionResult<Maestrafactura>> GetTaskItem(string id)
        {
            var taskItem = await _context.Maestrafacturas.FindAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return taskItem;
        }

        // DELETE: api/Todo/5
        [HttpDelete("{maestro_id}")]
        public async Task<IActionResult> DeleteTaskItem(string id)
        {
            var TaskItem = await _context.Maestrafacturas.FindAsync(id);

            if (TaskItem == null)
            {
                return NotFound();
            }

            _context.Maestrafacturas.Remove(TaskItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
