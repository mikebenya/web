using Microsoft.EntityFrameworkCore;
namespace TaskSharpHTTP.Models
{
public class MorenitaContext : DbContext
{
public MorenitaContext(DbContextOptions<MorenitaContext> options) :
base(options)
{
}
public DbSet<Cliente> Clientes { get; set; }
public DbSet<Detallefactura> Detallefacturas { get; set; }
public DbSet<Maestrafactura> Maestrafacturas { get; set; }
public DbSet<Producto> Productos { get; set; }
public DbSet<Vendedor> Vendedores { get; set; }
}
}