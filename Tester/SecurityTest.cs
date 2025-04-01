using DataModels.EntityFramework.MarketData.Contexts;
using DataModels.EntityFramework.SecurityMaster.Contexts;
using DataModels.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Tester
{
    public class SecurityTest(SecurityMasterContext securityMasterContext, MarketDataContext marketDataContext)
    {
        public async Task RunAsync()
        {
            var currencies = await securityMasterContext.Currencies.ToListAsync();
            var countries = await securityMasterContext.Countries.ToListAsync();
            var country = countries.First();
            ICountry countryInterface = countries.First();
            var countryCurrencies = countries.Select(c => c.Currency).ToList(); // No async needed here

            var spxSecurities = await securityMasterContext.Securities
                .Where(lmb => lmb.Symbol == "SPX" && lmb.ExchangeId == 4)
                .ToListAsync();

            int[] spxSecurityIds = spxSecurities.Select(lmb => lmb.Id).ToArray();

            var spxSecurityPrices = await marketDataContext.EquityPrices
                .Where(lmb => spxSecurityIds.Contains(lmb.SecurityId))
                .ToListAsync();

            Console.WriteLine($"SPX Security Prices Count: {spxSecurityPrices.Count}");
        }
    }
}
