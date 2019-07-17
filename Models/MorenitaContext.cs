using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess;

namespace TaskSharpHTTP.Models
{
public class MorenitaContext : DbContext
{
public MorenitaContext(DbContextOptions<MorenitaContext> options) :
base(options)
{
}
public DbSet<Cliente> Clientes { get; set; }
public DbSet<FacturaDetalle> FacturaDetalles { get; set; }
public DbSet<FacturaMaestro> FacturaMaestros { get; set; }
public DbSet<Producto> Productos { get; set; }
public DbSet<Vendedor> Vendedores { get; set; }
}
}