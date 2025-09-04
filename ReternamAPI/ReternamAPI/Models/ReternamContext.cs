using Microsoft.EntityFrameworkCore;

namespace ReternamApi.Models
{
    public class ReternamContext : DbContext
    {
        public ReternamContext(DbContextOptions<ReternamContext> options)
            : base(options)
        {
        }

        public DbSet<Deceased> Deceaseds { get; set; } = null!;
        public DbSet<Grave> Graves { get; set; } = null!;
        public DbSet<GraveType> GraveTypes { get; set; } = null!;
    }
}
