using Microsoft.EntityFrameworkCore;

namespace TaxCalculator.Models {
    public class TaxRateContext: DbContext {
        protected TaxRateContext() {
        }

        public TaxRateContext(DbContextOptions options) : base(options) {
        }

        public DbSet<TaxRate> TaxRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TaxRate>().HasData(
                new TaxRate(1, 0, 49020, 15, Type.FEDERAL),
                new TaxRate(2, 49020, 98040, 20.5f, Type.FEDERAL),
                new TaxRate(3, 98040, 151978, 26, Type.FEDERAL),
                new TaxRate(4, 151978, 216511, 29, Type.FEDERAL),
                new TaxRate(5, 216511, 1000000000, 33, Type.FEDERAL),
                
                new TaxRate(6, 0, 46295, 15, Type.PROVINCIAL),
                new TaxRate(7, 46295, 92580, 20, Type.PROVINCIAL),
                new TaxRate(8, 92580, 112655, 24, Type.PROVINCIAL), 
                new TaxRate(9, 112655, 100000000, 25.75f, Type.PROVINCIAL)
            );
        }
    }
}
