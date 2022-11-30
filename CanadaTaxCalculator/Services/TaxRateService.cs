using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using TaxCalculator.Models;

namespace TaxCalculator.Services {
    public class TaxRateService {
        private readonly TaxRateContext _context;

        public TaxRateService(TaxRateContext context) {
            _context = context;
        }

        public async Task<IList<TaxRate>> Get() {
            return await _context.TaxRates.ToListAsync();
        }

        public async Task<IList<TaxRate>?> GetByType(Models.Type type) {
            return await _context.TaxRates.Where(t => t.Type == type).ToListAsync();
        }
    }
}
