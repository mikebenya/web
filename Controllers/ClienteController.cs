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
    public class ClienteController : ControllerBase
    {
        private readonly MorenitaContext _context;

        public ClienteController(MorenitaContext context)
        {
            _context = context;

            if (_context.Clientes.Count() == 0)
            {
                _context.Clientes.Add(new Cliente { CLIENTE_ID = "1", CLIENTE_NOMBRE1 ="Mike ",CLIENTE_NOMBRE2 ="Yamith ",CLIENTE_APELLIDO1 ="Benya",CLIENTE_APELLIDO2="Amaya",CLIENTE_CALLE = "calle 29",CLIENTE_CASA = "#44-29",CLIENTE_BARRIO = "alamos",CLIENTE_FECHAN = "calle 29",CLIENTE_TELEFONO = "3003148827",CLIENTE_EMAIL = "mike@gmail.com"});
                _context.Clientes.Add(new Cliente { CLIENTE_ID = "2", CLIENTE_NOMBRE1 ="Carlos ",CLIENTE_NOMBRE2 ="Yamith ",CLIENTE_APELLIDO1 ="Cotes",CLIENTE_APELLIDO2="Amaya",CLIENTE_CALLE = "calle 13",CLIENTE_CASA = "#44-29",CLIENTE_BARRIO = "alamos",CLIENTE_FECHAN = "calle 29",CLIENTE_TELEFONO = "3003148827",CLIENTE_EMAIL = "mike@gmail.com"});
                _context.Clientes.Add(new Cliente { CLIENTE_ID = "3", CLIENTE_NOMBRE1 ="Miguel",CLIENTE_NOMBRE2 ="Yamith ",CLIENTE_APELLIDO1 ="Barros",CLIENTE_APELLIDO2="Amaya",CLIENTE_CALLE = "calle 66",CLIENTE_CASA = "#44-29",CLIENTE_BARRIO = "alamos",CLIENTE_FECHAN = "calle 29",CLIENTE_TELEFONO = "3003148827",CLIENTE_EMAIL = "mike@gmail.com" });
                _context.SaveChanges();
            }
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostTaskItem(Cliente item)
        {
            _context.Clientes.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTaskItem), new { id = item.CLIENTE_ID }, item);
        }
        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskItem(string id, Cliente item)
        {
            if (id!= (item.CLIENTE_ID))
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
        public async Task<ActionResult<IEnumerable<Cliente>>> GetTaskItems()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetTaskItem(string id)
        {
            var taskItem = await _context.Clientes.FindAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return taskItem;
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(string id)
        {
            var TaskItem = await _context.Clientes.FindAsync(id);

            if (TaskItem == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(TaskItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
