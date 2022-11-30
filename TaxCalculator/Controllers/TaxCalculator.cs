using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Services;

namespace IncomeTaxCalculator.Controllers {
    [Route("api/calculator")]
    [ApiController]
    public class TaxCalculator : ControllerBase {
        private readonly TaxRateService _taxRateService;
        private CanadaTaxCalculator.Controllers.TaxCalculator canadaTaxCalculator;
        private QuebecTaxCalculator.Controllers.TaxCalculator quebecTaxCalculator;

        public TaxCalculator(TaxRateService taxRateService) {
            this._taxRateService = taxRateService;
            this.canadaTaxCalculator = new CanadaTaxCalculator.Controllers.TaxCalculator();
            this.quebecTaxCalculator = new QuebecTaxCalculator.Controllers.TaxCalculator();
        }

        [HttpGet("{income}")]
        public async Task<object> calculateIncomeTax(double income) {
            var canadaTax = await canadaTaxCalculator.calculateIncomeTax(income);
            var quebecTax = await quebecTaxCalculator.calculateIncomeTax(income);
            return (canadaTax, quebecTax);
        }
    }
}
