using Microsoft.EntityFrameworkCore;
using ParibuApiServices.Models;

namespace ParibuApiServices.DbOperation
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        
    }
}
