using Microsoft.AspNetCore.Mvc;

namespace TaxCalculator.Controllers {
    public class HomeController : ControllerBase {
        [Route("/")]
        [HttpGet]
        public string GetWelcomMessage() {
            return "Welcome to Canada Income Tax Calculator 2021 API";
        }
    }
}
