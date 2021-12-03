using ExchangeOffice.Common;
using Microsoft.EntityFrameworkCore;

namespace ExchangeOffice.Repositories
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(Configuration.ConnectionString == null)
            {
                throw new ArgumentNullException(nameof(Configuration.ConnectionString));
            }
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
