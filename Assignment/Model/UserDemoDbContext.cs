using Microsoft.EntityFrameworkCore;

namespace Assignment.Model
{
    public class UserDemoDbContext : DbContext
    {
        public UserDemoDbContext(DbContextOptions<UserDemoDbContext> options):base(options)
        {
            
        }
        public DbSet<User>User { get; set; }
    }
}

