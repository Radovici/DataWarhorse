using DataLayer.Positions;
using DataModels.Interfaces;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PositionFramework
{
    public class Position : IPosition, IDisposable
    {
        private readonly string _guid = Guid.NewGuid().ToString();

        private readonly IPosition _parent;
        private readonly PositionGrouping _positionGrouping;
        private readonly IEnumerable<IDailyPosition> _dailyPositions;
        private bool disposedValue;

        public Position(IPosition? parent, PositionGrouping positionGroupBy, IEnumerable<IDailyPosition> dailyPositions)
        {
            _parent = parent;
            _positionGrouping = positionGroupBy;
            _dailyPositions = dailyPositions;
        }

        public Portfolio Portfolio
        {
            get
            {
                return this.GetPortfolio();
            }
        }

        public IPosition Parent
        {
            get
            {
                return _parent;
            }
        }

        public PositionGrouping Grouping { get { return _positionGrouping; } }

        public string Security
        {
            get
            {
                string security;
                int numSecurities = DailyPositions.Select(lmb => lmb.Security).Distinct().Count();
                if (numSecurities > 1)
                {
                    security = string.Format("{0} securities...", numSecurities);
                }
                else if (numSecurities == 1)
                {
                    security = DailyPositions.First().Security.Display;
                }
                else
                {
                    security = double.NaN.ToString();
                }
                return security;
            }
        }

        public IPosition StartPosition
        {
            get
            {
                DateTime startDate = StartDate;
                IEnumerable<IDailyPosition> dailyPositions = DailyPositions.Where(lmb => lmb.Date == startDate);
                PositionGrouping positionGrouping = new PositionGrouping(_positionGrouping, startDate, null, null, null, null, null, null, null, null);
                Position startPosition = new Position(this, positionGrouping, dailyPositions);
                return startPosition;
            }
        }

        public IPosition EndPosition
        {
            get
            {
                DateTime endDate = EndDate;
                IEnumerable<IDailyPosition> dailyPositions = DailyPositions.Where(lmb => lmb.Date == endDate);
                PositionGrouping positionGrouping = new PositionGrouping(_positionGrouping, endDate, null, null, null, null, null, null, null, null);
                Position endPosition = new Position(this, positionGrouping, dailyPositions);
                return endPosition;
            }
        }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get { return _dailyPositions.Min(lmb => lmb.Date); } }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get { return _dailyPositions.Max(lmb => lmb.Date); } }

        public IEnumerable<IDailyPosition> StartDailyPositions
        {
            get
            {
                DateTime date = StartDate;
                return _dailyPositions.Where(lmb => lmb.Date == date);
            }
        }

        public IEnumerable<IDailyPosition> EndDailyPositions
        {
            get
            {
                DateTime date = EndDate;
                return _dailyPositions.Where(lmb => lmb.Date == date);
            }
        }

        public IEnumerable<IDailyPosition> DailyPositions { get { return _dailyPositions; } }

        public double Pnl => throw new NotImplementedException();

        public double OpenMarketValue => throw new NotImplementedException();

        public double StartMarketValue => throw new NotImplementedException();

        public double EndMarketValue => throw new NotImplementedException();

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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Position()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
