using EntityLayer.Concrete;
using System.Data.Entity;

namespace DataAccessLayer.Context
{
    public class NTierContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
