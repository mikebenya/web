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
    public class ProductoController : ControllerBase
    {
        private readonly MorenitaContext _context;

        public ProductoController(MorenitaContext context)
        {
            _context = context;

            if (_context.Productos.Count() == 0)
            {
                _context.Productos.Add(new Producto { PRODUCTO_ID = "1", PRODUCTO_NOMBRE= "fresa",PRODUCTO_PRECIO = 16000,PRODUCTO_DESCRIPCION = "4 fresa con rosa ",PRODUCTO_COSTO=19200,PRODUCTO_IMAGEN="assets/Imagenes/rosa4.jpeg",PRODUCTO_ESTADO=false});
                _context.Productos.Add(new Producto { PRODUCTO_ID = "2", PRODUCTO_NOMBRE= "fresa con chocolate",PRODUCTO_PRECIO = 16000,PRODUCTO_DESCRIPCION = "4 fresa con rosa ",PRODUCTO_COSTO=19200,PRODUCTO_IMAGEN="assets/Imagenes/rosa6.jpeg",PRODUCTO_ESTADO=false});
                _context.Productos.Add(new Producto { PRODUCTO_ID = "3", PRODUCTO_NOMBRE= "fresa y cerveza",PRODUCTO_PRECIO = 16000,PRODUCTO_DESCRIPCION = "4 fresa con rosa ",PRODUCTO_COSTO=19200,PRODUCTO_IMAGEN="assets/Imagenes/rosacoro.jpeg",PRODUCTO_ESTADO=false});
               _context.SaveChanges();
            }
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Producto>> PostTaskItem(Producto item)
        {
            _context.Productos.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaskItem), new { id = item.PRODUCTO_ID }, item);
        }
        // PUT: api/Task/5
        [HttpPut("{producto_id}")]
        public async Task<IActionResult> PutTaskItem(string id, Producto item)
        {
            if (id != item.PRODUCTO_ID)
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
        public async Task<ActionResult<IEnumerable<Producto>>> GetTaskItems()
        {
            return await _context.Productos.ToListAsync();
        }

        // GET: api/Task/5
        [HttpGet("{producto_id}")]
        public async Task<ActionResult<Producto>> GetTaskItem(string id)
        {
            var taskItem = await _context.Productos.FindAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return taskItem;
        }

        // DELETE: api/Todo/5
        [HttpDelete("{producto_id}")]
        public async Task<IActionResult> DeleteTaskItem(string id)
        {
            var TaskItem = await _context.Productos.FindAsync(id);

            if (TaskItem == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(TaskItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
