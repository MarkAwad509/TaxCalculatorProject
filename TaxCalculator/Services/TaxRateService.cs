using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using TaxCalculator.Models;

namespace TaxCalculator.Services {
    public class TaxRateService {
        private readonly TaxRateContext _context;
        private readonly IHttpClientFactory _clientFactory;

        public TaxRateService(TaxRateContext context, IHttpClientFactory factory) {
            _context = context;
            _clientFactory = factory;
        }

        public async Task<IList<TaxRate>> Get() {
            return await _context.TaxRates.ToListAsync();
        }

        public async Task<IList<TaxRate>?> GetByType(Models.Type type) {
            return await _context.TaxRates.Where(t => t.Type == type).ToListAsync();
        }

        public async Task<double> GetQuebecPayable(double income) {
            var uri = "api/qc/calculator/" + income;
            var client = _clientFactory.CreateClient(name: "QuebecTaxCalculator");
            var request = client.BaseAddress + uri;

            try {
                var response = await client.GetAsync(request);
                response.EnsureSuccessStatusCode();
                string apiResponse = await response.Content.ReadAsStringAsync();
                var qcPayable = JsonConvert.DeserializeObject<double>(apiResponse);
                return qcPayable;
            } catch (Exception e) {
                Debug.WriteLine(e);
            }
            return 0;
        }

        public async Task<double> GetCanadaPayable(double income) {
            var uri = "api/ca/calculator/" + income;
            var client = _clientFactory.CreateClient(name: "CanadaTaxCalculator");
            var request = client.BaseAddress + uri;

            try {
                var response = await client.GetAsync(request);
                response.EnsureSuccessStatusCode();
                string apiResponse = await response.Content.ReadAsStringAsync();
                var qcPayable = JsonConvert.DeserializeObject<double>(apiResponse);
                return qcPayable;
            } catch (Exception e) {
                Debug.WriteLine(e);
            }
            return 0;
        }
    }
}
