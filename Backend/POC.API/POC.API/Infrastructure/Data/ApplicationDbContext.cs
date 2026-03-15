using Microsoft.EntityFrameworkCore;
using POC.API.Domain.Entities;

namespace POC.API.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
