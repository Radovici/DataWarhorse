using CommonFunctions;
using DataLayer.Positions;
using DataModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionFramework
{
    public static class DailyPositionExtensions
    {
        public static PositionGrouping GetGrouping(this IDailyPosition dailyPosition)
        {
            return new PositionGrouping(dailyPosition.Date, dailyPosition.Fund, dailyPosition.Security, dailyPosition.Security.UnderlyingSecurity);
        }

        public static DateTime GetStartDate(this IDailyPosition dailyPosition)
        {
            return dailyPosition.Date;
        }

        public static DateTime GetEndDate(this IDailyPosition dailyPosition)
        {
            return dailyPosition.Date;
        }

        public static double GetPnl(this IDailyPosition dailyPosition, IEnumerable<ITrade> trades)
        {
            //if (dailyPosition.Security is ContractForDifference && trades.Any())
            //{
            //    return 0; // HACK: zero out starting CFDs (not calculated correctly)
            //}
            double tradeCost = trades != null && trades.Any() ? trades.Sum(lmb => lmb.Cost) : 0;
            return dailyPosition.GetEndMarketValue() - dailyPosition.GetStartMarketValue() - tradeCost;
        }

        public static double GetStartMarketValue(this IDailyPosition dailyPosition)
        {
            DateTime previousBusinessDate = dailyPosition.Date.ToPreviousBusinessDate();
            return dailyPosition.Security.GetMarketValue(previousBusinessDate, dailyPosition.StartQuantity);
        } //NOTE: need split adjustments.        

        public static double GetEndMarketValue(this IDailyPosition dailyPosition) { return dailyPosition.Security.GetMarketValue(dailyPosition.Date, dailyPosition.EndQuantity); }

        public static double GetOpenMarketValue(this IDailyPosition dailyPosition, IEnumerable<ITrade> trades)
        {
            double startMarketValue = dailyPosition.GetStartMarketValue();
            if (startMarketValue.IsZero())
            {
                if (trades != null && trades.Any())
                {
                    startMarketValue = trades.Sum(lmb => lmb.MarketValue);
                }
            }
            return startMarketValue;
        }

        public static double GetStartDeltaExposure(this IDailyPosition dailyPosition)
        {
            if (!dailyPosition.Security.IsOption()) return dailyPosition.GetStartMarketValue();
            DateTime previousBusinessDate = dailyPosition.Date.ToPreviousBusinessDate();
            return dailyPosition.Security.GetDeltaExposure(previousBusinessDate, dailyPosition.StartQuantity); //_unadjustedStartQuantity);
        }

        public static double GetEndDeltaExposure(this IDailyPosition dailyPosition)
        {
            if (!dailyPosition.Security.IsOption()) return dailyPosition.GetEndMarketValue();
            return dailyPosition.Security.GetDeltaExposure(dailyPosition.Date, dailyPosition.EndQuantity);
        }

        public static double GetOpenDeltaExposure(this IDailyPosition dailyPosition, IEnumerable<ITrade> trades)
        {
            double exposure = dailyPosition.GetStartDeltaExposure();
            if (exposure.IsZero())
            {
                if (trades != null && trades.Any())
                {
                    exposure = trades.Sum(lmb => lmb.DeltaExposure);
                }
            }
            return exposure;
        }

        public static double GetStartBetaExposure(this IDailyPosition dailyPosition)
        {
            NameValueCollection nameValues = new NameValueCollection();
            nameValues[Constants.Date] = dailyPosition.Date.ToPreviousBusinessDate().ToShortDateString();
            return dailyPosition.GetStartDeltaExposure() * dailyPosition.Security.UnderlyingSecurity.GetBeta(nameValues);
        }

        public static double GetEndBetaExposure(this IDailyPosition dailyPosition)
        {
            NameValueCollection nameValueCollection = new NameValueCollection();
            nameValueCollection[Constants.Date] = dailyPosition.Date.ToShortDateString();
            return GetEndBetaExposureTo(dailyPosition, nameValueCollection);
        }

        public static double GetEndBetaExposureTo(this IDailyPosition dailyPosition, NameValueCollection nameValueCollection)
        {
            return dailyPosition.GetEndDeltaExposure() * dailyPosition.Security.UnderlyingSecurity.GetBeta(nameValueCollection);
        }

        public static double GetAlphaPnl(this IDailyPosition dailyPosition)
        {
            NameValueCollection nameValues = new NameValueCollection();
            nameValues[Constants.Date] = dailyPosition.Date.ToShortDateString();
            double result = dailyPosition.OpenMarketValue * dailyPosition.Security.GetAlphaReturn(nameValues); //HACK 20180723: note, this isn't correct, need to correct for traded position
            return result;
        }
    }
}
