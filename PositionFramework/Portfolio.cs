﻿using CommonFunctions;
using Core.Interfaces.DataModels;
using Core.Interfaces.Services;
using DataLayer.Positions;
using System.Diagnostics;

namespace PositionFramework
{
    public class Portfolio : Position
    {
        public Portfolio(IEnumerable<IDailyPosition> dailyPositions)
            : base(null, PositionGrouping.Empty, dailyPositions) // new DailyPositionGrouping(dailyPositions))
        {
        }

        public Portfolio(IEnumerable<ITrade> trades, IMarketDataService marketDataService)
            : this(GetDailyPositions(trades, marketDataService))
        {
        }

        public static IEnumerable<IDailyPosition> GetDailyPositions(IEnumerable<ITrade> trades, IMarketDataService marketDataService) //IGrouping<PositionGroupBy, IDailyPosition>
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            IEnumerable<DateOnly> dates = trades.Min(lmb => lmb.TradeDate).To(DateOnly.FromDateTime(DateTime.Today), true); // new List<DateOnly>(); // DataApi.Singleton.PricingStartDate.To(DataApi.Singleton.PricingEndDate, true).ToList();
            List<DailyPosition> dailyPositions = new List<DailyPosition>();
            foreach (var tradesByDailyPositionGrouping in trades.GroupBy(lmb => new { lmb.Fund, lmb.Security })) // NOTE: GroupBy DailyPositionGrouping (finest granularity)
            {
                Console.Write(string.Format("Creating DailyPositions for Fund={0}, Security={1}.", tradesByDailyPositionGrouping.Key.Fund.Name, tradesByDailyPositionGrouping.Key.Security.Name));
                DateOnly maxSecurityDate = tradesByDailyPositionGrouping.Key.Security.EndDate; // dates.Max();
                SortedDictionary<DateOnly, IEnumerable<ITrade>> tradesByDate =
                    new SortedDictionary<DateOnly, IEnumerable<ITrade>>(
                        tradesByDailyPositionGrouping.GroupBy(lmb => lmb.TradeDate).ToDictionary(lmb => lmb.Key,
                                                                                                 lmb => lmb.AsEnumerable())); //descending because IsLong=TRUE/1 before IsLong=FALSE/0
                DateOnly from = tradesByDate.Keys.Min(); //tradesByDailyPositionGrouping.Min(lmb => lmb.TradeDate));                
                DateOnly to = DateTimeExtensions.Min(tradesByDate.Keys.Max().AddBusinessDays(1), maxSecurityDate);
                DailyPosition? previousDailyPosition = null; // first DailyPosition doesn't have a predecessor
                double quantity = 0;
                Console.Write(string.Format("\tFrom={0}, To={1}: ", from.ToShortDateString(), to.ToShortDateString()));
                foreach (DateOnly dt in dates.Where(lmb => lmb >= from && lmb <= maxSecurityDate))
                {
                    Console.Write("."); // string.Format("{0}{1}", dt.ToShortDateString(), dt < maxSecurityDate ? "," : string.Empty));
                    IEnumerable<ITrade>? datedTrades;
                    if (tradesByDate.TryGetValue(dt, out datedTrades))
                    {
                        dailyPositions.Add(previousDailyPosition = new DailyPosition(dt, datedTrades, previousDailyPosition, marketDataService));
                        quantity += previousDailyPosition.TradedQuantity;
                        //foreach(ITrade trade in datedTrades) //TODO: dailyPosition should have multiple trades
                        //{
                        //    quantity += trade.Quantity;
                        //    dailyPositions.Add(previousDailyPosition = new DailyPosition(dt, trade, previousDailyPosition));
                        //}                        
                    }
                    else
                    {
                        if (quantity == 0) //quantity's zero and T has no trades (so it must've been zero on T-1)
                        {
                            if (dt > to)
                            {
                                break; //there are no more trades going forward
                            }
                            else
                            {
                                continue; //there are more trades later                                
                            }
                        }
                        dailyPositions.Add(previousDailyPosition = new DailyPosition(dt, null, previousDailyPosition, marketDataService));
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(); //newline
            sw.Stop();
            Debug.WriteLine("PositionFramework.Portfolio.GetDailyPositions(trades) ElapsedMilliseconds = {0}.", sw.ElapsedMilliseconds);
            return dailyPositions; //new DailyPositionGrouping(dailyPositions);
        }
    }
}
