using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskSharpHTTP.Models;
using System.Data;
using System;

namespace TaskSharpHTTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaMaestroController : ControllerBase
    {
        private readonly MorenitaContext _context;

        public FacturaMaestroController(MorenitaContext context)
        {
             Producto producto1 = new Producto { PRODUCTO_ID = "1", PRODUCTO_NOMBRE= "fresa",PRODUCTO_PRECIO = 16000,PRODUCTO_DESCRIPCION = "4 fresa con rosa ",PRODUCTO_COSTO=19200,PRODUCTO_IMAGEN="assets/Imagenes/rosa4.jpeg",PRODUCTO_ESTADO=false,PRODUCTO_IVA=0};
             Cliente cliente1 = new Cliente { CLIENTE_ID = "1", CLIENTE_NOMBRE1 ="Mike ",CLIENTE_NOMBRE2 ="Yamith ",CLIENTE_APELLIDO1 ="Benya",CLIENTE_APELLIDO2="Amaya",CLIENTE_CALLE = "calle 29",CLIENTE_CASA = "#44-29",CLIENTE_BARRIO = "alamos",CLIENTE_FECHAN =new DateTime(1999,7,27),CLIENTE_TELEFONO = "3003148827",CLIENTE_EMAIL = "mike@gmail.com",facturaMaestros=null };
            Vendedor vendedor1 = new Vendedor { VENDEDOR_ID = "1", VENDEDOR_NOMBRE1_VEN = "Maicool ", VENDEDOR_NOMBRE2_VEN = "Yamith ", VENDEDOR_APELLIDO1_VEN = "Benjumea", VENDEDOR_APELLIDO2_VEN = "Amaya", VENDEDOR_CALLE_VEN = "calle 29", VENDEDOR_CASA_VEN = "#44-29", VENDEDOR_BARRIO_VEN = "alamos", VENDEDOR_TELEFONO_VEN = "3003148827", VENDEDOR_USUARIO = "mikeBenya", VENDEDOR_CONTRASENA = "1127" };
            
            List<FacturaDetalle> fDetalles = new List<FacturaDetalle>();
            fDetalles.Add(new FacturaDetalle { DETALLE_ID = "FD1", Producto = producto1, DETALLE_CANTIDAD = 3, DETALLE_FECHA = DateTime.Now });
          _context = context;

            if (_context.FacturaMaestros.Count() == 0)
            {
                _context.FacturaMaestros.Add(new FacturaMaestro { MAESTRO_ID = "1", MAESTRO_FECHA = DateTime.Now,  Cliente = null, facturaDetalles = null, Vendedor = null});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaMaestro>>> GetFacturas()
        {
            return await _context.FacturaMaestros.Include(c=>c.Cliente).Include(v=>v.Vendedor).Include(v=>v.facturaDetalles).ThenInclude(p=>p.Producto).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<FacturaMaestro>> PostCliente(FacturaMaestro newFactura)
        {
            var facturaItem = await _context.FacturaMaestros.FindAsync(newFactura.MAESTRO_ID);
            if (facturaItem != null)
            {
                return BadRequest();
            }
            else
            {
                _context.FacturaMaestros.Add(newFactura);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCliente), new { id = newFactura.MAESTRO_ID }, newFactura);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaMaestro>> GetCliente(string id)
        {
            var facturaItem = await _context.FacturaMaestros.FindAsync(id);

            if (facturaItem == null)
            {
                return NotFound();
            }

            return facturaItem;
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(string id)
        {
            var facturaItem = await _context.FacturaMaestros.FindAsync(id);

            if (facturaItem == null)
            {
                return NotFound();
            }

            _context.FacturaMaestros.Remove(facturaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
