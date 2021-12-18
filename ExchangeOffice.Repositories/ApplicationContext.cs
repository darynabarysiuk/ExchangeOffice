using ExchangeOffice.Common;
using ExchangeOffice.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExchangeOffice.Repositories
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Casher> Cashers { get; set; }

        public DbSet<Currency> Сurrencies { get; set; }

        public DbSet<СurrencyLimit> СurrencyLimits { get; set; }

        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        public DbSet<OperationHistory> OperationHistories { get; set; }

        public ApplicationContext()
            : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Configuration.ConnectionString == null)
            {
                throw new ArgumentNullException(nameof(Configuration.ConnectionString));
            }
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Currency>()
                .HasOne(u => u.СurrencyLimit)
                .WithOne(p => p.Сurrency)
                .HasForeignKey<СurrencyLimit>(p => p.CurrencyID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<Currency>()
                .HasMany(u => u.CurrencyRateFrom)
                .WithOne(p => p.CurrencyFrom)
                .HasForeignKey(p => p.CurrencyIDFrom)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Currency>()
                .HasMany(u => u.CurrencyRateTo)
                .WithOne(p => p.CurrencyTo)
                .HasForeignKey(p => p.CurrencyIDTo)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<CurrencyRate>()
                .HasMany(u => u.OperationHistories)
                .WithOne(p => p.CurrencyRate)
                .HasForeignKey(p => p.CurrencyRateID);
        }
    }
}
