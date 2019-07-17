using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskSharpHTTP.Models;
using System;

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
                _context.Clientes.Add(new Cliente { CLIENTE_ID = "1", CLIENTE_NOMBRE1 ="Mike ",CLIENTE_NOMBRE2 ="Yamith ",CLIENTE_APELLIDO1 ="Benya",CLIENTE_APELLIDO2="Amaya",CLIENTE_CALLE = "calle 29",CLIENTE_CASA = "#44-29",CLIENTE_BARRIO = "alamos",CLIENTE_FECHAN =new DateTime(1999,7,27),CLIENTE_TELEFONO = "3003148827",CLIENTE_EMAIL = "mike@gmail.com",facturaMaestros=null});
                _context.Clientes.Add(new Cliente { CLIENTE_ID = "2", CLIENTE_NOMBRE1 ="Carlos ",CLIENTE_NOMBRE2 ="Yamith ",CLIENTE_APELLIDO1 ="Cotes",CLIENTE_APELLIDO2="Amaya",CLIENTE_CALLE = "calle 13",CLIENTE_CASA = "#44-29",CLIENTE_BARRIO = "alamos",CLIENTE_FECHAN =new DateTime(2000,2,2) ,CLIENTE_TELEFONO = "3003148827",CLIENTE_EMAIL = "mike@gmail.com",facturaMaestros=null});
                _context.Clientes.Add(new Cliente { CLIENTE_ID = "3", CLIENTE_NOMBRE1 ="Miguel",CLIENTE_NOMBRE2 ="Yamith ",CLIENTE_APELLIDO1 ="Barros",CLIENTE_APELLIDO2="Amaya",CLIENTE_CALLE = "calle 66",CLIENTE_CASA = "#44-29",CLIENTE_BARRIO = "alamos",CLIENTE_FECHAN =new DateTime(2004,8,27) ,CLIENTE_TELEFONO = "3003148827",CLIENTE_EMAIL = "mike@gmail.com" ,facturaMaestros=null});
                _context.SaveChanges();
            }
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente newcliente)
        {
             var varCliente = await _context.Clientes.FindAsync(newcliente.CLIENTE_ID) ;
            if (varCliente!=null)
            {
                return BadRequest();
            }else{
                _context.Clientes.Add(newcliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCliente), new { id = newcliente.CLIENTE_ID }, newcliente);
            }
            
        }
        // PUT: api/cliente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(string id, Cliente itemCliente)
        {
            if (id!= (itemCliente.CLIENTE_ID))
            {
                return BadRequest();
            }
            _context.Entry(itemCliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(string id)
        {
            var clienteItem = await _context.Clientes.FindAsync(id);

            if (clienteItem == null)
            {
                return NotFound();
            }

            return clienteItem;
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(string id)
        {
            var ClienteItem = await _context.Clientes.FindAsync(id);

            if (ClienteItem == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(ClienteItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
