using DataModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFunctions
{
    public static class TradeExtensions
    {
        public static double GetOpenMarketValue(this ITrade trade, bool IsLongMarketValue)
        {
            if (trade == null) return 0;
            return IsLongMarketValue == trade.IsLongMarketValue() ? trade.MarketValue : 0;
        }

        public static bool IsLongMarketValue(this ITrade trade)
        {
            return trade.MarketValue > 0;
        }
    }
}
