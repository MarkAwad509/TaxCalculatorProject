using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TaxCalculator.Services;

namespace IncomeTaxCalculator.Controllers {
    [Route("api/calculator")]
    [ApiController]
    public class TaxCalculator : ControllerBase {
        private readonly TaxRateService _taxRateService;

        public TaxCalculator(TaxRateService taxRateService) {
            _taxRateService = taxRateService;
        }

        [HttpGet("{income}")]
        public async Task<string> calculateIncomeTax(double income) {
            var qcPayable = await _taxRateService.GetQuebecPayable(income);
            var caPayable = await _taxRateService.GetCanadaPayable(income);

            var total = qcPayable + caPayable;
            var net = income - total;

            return $"Total payable amount: {total}," +
                $"Net income: {net}";
        }
    }
}