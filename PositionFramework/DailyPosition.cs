﻿using Core.Interfaces.DataModels;
using Core.Interfaces.Services;
using DataLayer.Positions;
using PositionFramework.Extensions;

namespace PositionFramework
{
    public class DailyPosition : IDailyPosition
    {
        private readonly DateOnly _date;
        private readonly IEnumerable<ITrade>? _trades;
        private readonly DailyPosition? _previousDailyPosition;
        private readonly IMarketDataService _marketDataService;

        private readonly IFund _fund;
        private readonly ISecurity _security;

        //private readonly double _unadjustedStartQuantity;
        //private readonly double _splitRatio;

        /// <summary>
        /// A DailyPosition can be made up of a previous DailyPosition (last business date's DailyPosition) and today's trades.
        /// </summary>
        public DailyPosition(DateOnly dt, IEnumerable<ITrade>? trades, DailyPosition? previousDailyPosition, IMarketDataService marketDataService)
        {
            this._marketDataService = marketDataService;
            if (trades != null && trades.Any())
            {
                var funds = trades.Select(lmb => lmb.Fund).Distinct().ToList();
                var securities = trades.Select(lmb => lmb.Security).Distinct().ToList();
                if (funds.Count() > 1 || securities.Count() > 1)
                {
                    throw new ArgumentException(
                        string.Format("DailyPosition(..): there must be one fund or security, there are {0} fund(s) and {1} security(ies).",
                            funds.Count(),
                            securities.Count()));
                }
                _fund = funds.Single();
                _security = securities.Single();
            }

            _date = dt;
            _trades = trades;
            _previousDailyPosition = previousDailyPosition;
            if (_previousDailyPosition != null)
            {
                if (_fund == null)
                {
                    _fund = _previousDailyPosition.Fund; // must get the fund from the trades or previous daily position (otherwise throw an exception)
                }
                if (_security == null)
                {
                    _security = _previousDailyPosition.Security;
                }
            }

            if (_fund == null || _security == null)
            {
                throw new NullReferenceException($"DailyPosition must have both fund and security.");
            }
            // TODO: validate DailyPosition; throw exception if DailyPosition is unvalidated (doesn't have fund or security or something)

            //_unadjustedStartQuantity = UnadjustedStartQuantity;
            //_splitRatio = Security.GetSplitRatio(Date, Date);
        }

        public IFund Fund
        {
            get { return _fund; }
        }

        public ISecurity Security
        {
            get { return _security; }
        }

        public DateOnly Date
        {
            get { return _date; }
        }

        public IEnumerable<ITrade> Trades { get { return _trades ?? new ITrade[] { }; } }

        public double StartQuantity
        {
            get
            {
                return _previousDailyPosition != null
                    ? _previousDailyPosition.EndQuantity
                    : 0;

            }
        }

        public double EndQuantity
        {
            get { return StartQuantity + TradedQuantity; }
        }

        public double TradedQuantity
        {
            get { return _trades != null && _trades.Any() ? _trades.Sum(lmb => lmb.Quantity) : 0; }
        }

        public bool IsLong
        {
            get { return EndQuantity >= 0; }
        }

        public IPosition? Parent { get { return null; } } // HACK (20180716): IPosition Parent doesn't work for IDailyPositions
        public IEnumerable<IDailyPosition> DailyPositions { get { return new[] { this }; } }
        public PositionGrouping Grouping { get { return this.GetGrouping(); } }
        public DateOnly StartDate { get { return this.GetStartDate(); } }
        public DateOnly EndDate { get { return this.GetEndDate(); } }
        public double Pnl => this.EndMarketValue - (this.StartMarketValue + this.OpenMarketValue); // this._marketDataService.GetPrice(this.Security, this.Date); // TODO: implement this -- bit tricky with intraday trades and varying security types.

        public double OpenMarketValue => 0;
        // this.Trades
        //.Where(lmb => lmb.TradeType == TradeType.Open)
        //.Sum(lmb => lmb.Quantity * this._marketDataService.GetPrice(this.Security, this.Date).GetValueOrDefault(0));

        public double StartMarketValue => this._previousDailyPosition?.EndMarketValue ?? 0;

        public double EndMarketValue => this.EndQuantity * this._marketDataService.GetPrice(this.Security, this.Date).GetValueOrDefault(0);

        public double StartDeltaExposure => throw new NotImplementedException();

        public double EndDeltaExposure => throw new NotImplementedException();

        public double StartBetaExposure => throw new NotImplementedException();

        public double EndBetaExposure => throw new NotImplementedException();

        public double StartValueAtRisk => throw new NotImplementedException();

        public double EndValueAtRisk => throw new NotImplementedException();

        public double StartDailyVolatility => throw new NotImplementedException();

        public double EndDailyVolatility => throw new NotImplementedException();

        public double StartAum => throw new NotImplementedException();

        public double EndAum => throw new NotImplementedException();

        DateOnly IDailyPosition.Date => throw new NotImplementedException();
    }
}
