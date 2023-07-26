using Microsoft.EntityFrameworkCore;
using UserApi.DataModelLayer;

namespace UserApi.Service
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Appuser>app_user { get; set; }
        public DbSet<Usertype> user_type { get; set; }
    }
}
