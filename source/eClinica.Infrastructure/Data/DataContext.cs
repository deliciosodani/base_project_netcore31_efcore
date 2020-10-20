using eClinica.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace eClinica.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<AtencionDelDia> AtencionDelDia { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
        }
    }
}
