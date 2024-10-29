using Microsoft.EntityFrameworkCore;
using TargetCustomer.Models;

namespace TargetCustomer.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Consultoria> Consultorias { get; set; }
    }
}
