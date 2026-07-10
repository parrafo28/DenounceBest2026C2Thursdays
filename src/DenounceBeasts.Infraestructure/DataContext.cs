using DenounceBeasts.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.Infraestructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ComplaintType> ComplaintTypes { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
