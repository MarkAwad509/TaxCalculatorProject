using Microsoft.AspNetCore.Mvc;

namespace TaxCalculator.Controllers {
    public class HomeController : ControllerBase {
        [Route("/")]
        [HttpGet]
        public string GetWelcomeMessage() {
            return "Welcome to Income Tax Calculator 2021 API";
        }
    }
}
