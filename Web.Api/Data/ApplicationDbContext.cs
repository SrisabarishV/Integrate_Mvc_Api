using Microsoft.EntityFrameworkCore;
using Web.Api.Module;

namespace Web.Api.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Student> Students { get; set; }    
    }
}
