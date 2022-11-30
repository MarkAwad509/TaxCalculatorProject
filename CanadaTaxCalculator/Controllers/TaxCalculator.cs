using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Models;
using TaxCalculator.Services;
using Type = TaxCalculator.Models.Type;

namespace CanadaTaxCalculator.Controllers {
    [Route("api/ca/calculator")]
    [ApiController]
    public class TaxCalculator : ControllerBase {
        private readonly TaxRateService _taxRateService;

        public TaxCalculator(TaxRateService taxRateService) {
            _taxRateService = taxRateService;
        }

        public TaxCalculator() {
            var taxRateContext = new TaxRateContext();
            _taxRateService = new TaxRateService(taxRateContext);
        }

        [HttpGet("{income}")]
        public async Task<double> calculateIncomeTax(double income) {
            var rates = await _taxRateService.GetByType(Type.FEDERAL);
            double payable = 0;
            int i = 0;

            while (income > rates[i].Low) {
                if (income < rates[i].High) 
                    payable = payable + (income - rates[i].Low) * (rates[i].Rate / 100);
                else 
                    payable = payable + (rates[i].High - rates[i].Low) * (rates[i].Rate / 100);
                i++;
            }
            return payable;
        }
    }
}
