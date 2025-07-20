using Microsoft.EntityFrameworkCore;

namespace Form_Builder.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Form> Forms { get; set; }
        public DbSet<Models.FormFields> FormFields { get; set; }
    }
}
