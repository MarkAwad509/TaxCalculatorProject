using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Models;
using TaxCalculator.Services;
using Type = TaxCalculator.Models.Type;

namespace QuebecTaxCalculator.Controllers {
    [Route("api/qc/calculator")]
    [ApiController]
    public class TaxCalculator : ControllerBase {
        private readonly TaxRateService _taxRateService;

        public TaxCalculator(TaxRateService taxRateService) {
            _taxRateService = taxRateService;
        }

        [HttpGet("{income}")]
        public async Task<double> calculateIncomeTax(double income) {
            var rates = await _taxRateService.GetByType(Type.PROVINCIAL);
            double payable = 0;

            for (int i = 0; i < rates.Count; i++) {
                if (income <= rates[i].High)
                    payable = payable + (income - rates[i].Low) * (rates[i].Rate / 100);
                else
                    payable = payable + (rates[i].High - rates[i].Low) * (rates[i].Rate / 100);
            }
            return payable;
        }
    }
}
