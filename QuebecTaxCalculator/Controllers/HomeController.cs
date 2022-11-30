using Microsoft.AspNetCore.Mvc;

namespace TaxCalculator.Controllers {
    public class HomeController : ControllerBase {
        [Route("/qc")]
        [HttpGet]
        public string GetWelcomMessage() {
            return "Welcome to Quebec Income Tax Calculator 2021 API";
        }
    }
}
