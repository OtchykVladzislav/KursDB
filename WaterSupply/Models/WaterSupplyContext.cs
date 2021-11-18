using Microsoft.EntityFrameworkCore;

namespace WaterSupply.Models
{
    public class WaterSupplyContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<CounterMark> CounterMarks { get; set; }
        public DbSet<Counter> Counters { get; set; }
        public DbSet<Indicator> Indicators { get; set; }
        public DbSet<IndicatorCheck> IndicatorChecks { get; set; }

        public WaterSupplyContext(DbContextOptions<WaterSupplyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
