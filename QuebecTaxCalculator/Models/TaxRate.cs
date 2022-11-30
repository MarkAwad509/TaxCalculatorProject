using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Models {
    public enum Type { FEDERAL = 0, PROVINCIAL = 1 }
    public class TaxRate {
        [Key]
        public int Id { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public float Rate { get; set; }
        public Type Type { get; set; }
        public TaxRate(int Id, int low, int high, float rate, Type type) {
            this.Id = Id;
            Low = low;
            High = high;
            Rate = rate;
            Type = type;
        }
    }
}
