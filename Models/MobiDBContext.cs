using Microsoft.EntityFrameworkCore;
using mobisolProject.Models;

namespace mobisolProject.Models
{
    public class MobiDBContext : DbContext
    {
        public MobiDBContext(DbContextOptions<MobiDBContext> options)
                : base(options)
        {
        }

        public DbSet<Buy>         Buy { get; set; }
        public DbSet<Customer>    Customer { get; set; }
        public DbSet<Maintenance> Maintenance { get; set; }
        public DbSet<Payment>     Payment { get; set; }
        public DbSet<Products>    Products { get; set; }
        public DbSet<Purchase>    Purchase { get; set; }
        public DbSet<Staff>       Staff { get; set; }

    }
}