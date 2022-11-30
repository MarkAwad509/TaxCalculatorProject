using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Models;
using TaxCalculator.Services;

namespace TaxCalculator.Controllers {
    [ApiController]
    [Route("/api/taxrate")]
    public class TaxRateController : ControllerBase {
        private readonly TaxRateService _taxRateService;

        public TaxRateController(TaxRateService taxRateService) {
            _taxRateService = taxRateService;
        }

        [HttpGet]
        public async Task<IList<TaxRate>> Get() {
            return await _taxRateService.Get();
        }

        [HttpGet("{type}")]
        public async Task<ActionResult<IList<TaxRate>>> GetByType(Models.Type type) {
            var rate = await _taxRateService.GetByType(type);
            return rate is null ? NotFound($"Tax rate type {type.ToString().ToLower()} was not found."): Ok(rate);
        }
    }
}
