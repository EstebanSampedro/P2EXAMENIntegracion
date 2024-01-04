using Microsoft.EntityFrameworkCore;
using IntegracionP2ES.Models;
namespace IntegracionP2ES
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<CiudadesGeoreferenciadas> CiudadesGeoreferenciadas { get; set; }


        public DbSet<Cliente> Clientes { get; set; }
    }
}
