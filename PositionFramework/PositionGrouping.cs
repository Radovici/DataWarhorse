using DataModels.Interfaces;
using System.Diagnostics;

namespace DataLayer.Positions
{
    public class PositionGrouping : IComparable<PositionGrouping>
    {
        public class Function
        {
            //Func<IPosition, IDailyPosition, PositionGroupBy>            
            private Func<IPosition, IDailyPosition, PositionGrouping> _functionDelegate;
            private string _key;
            public Function(Func<IPosition, IDailyPosition, PositionGrouping> functionDelegate, string key)
            {
                _functionDelegate = functionDelegate;
                _key = key;
            }

            public Func<IPosition, IDailyPosition, PositionGrouping> FunctionDelegate
            {
                get { return _functionDelegate; }
            }

            public override string ToString()
            {
                return _key;
            }
        }

        public static PositionGrouping.Function GroupByDate { get { return new PositionGrouping.Function((pos, dp) => new PositionGrouping(dp.Date, null, null, null), MethodName); } }
        public static PositionGrouping.Function GroupByDateFund { get { return new PositionGrouping.Function((pos, lmb) => new PositionGrouping(lmb.Date, lmb.Fund, null, null), MethodName); } }
        public static PositionGrouping.Function GroupByDateFundUnderlyer { get { return new PositionGrouping.Function((pos, lmb) => new PositionGrouping(lmb.Date, lmb.Fund, null, lmb.Security.UnderlyingSecurity), MethodName); } }
        public static PositionGrouping.Function GroupByDateFundSecurity { get { return new PositionGrouping.Function((pos, lmb) => new PositionGrouping(lmb.Date, lmb.Fund, lmb.Security, null), MethodName); } }
        public static PositionGrouping.Function GroupByDateSecurity { get { return new PositionGrouping.Function((pos, lmb) => new PositionGrouping(lmb.Date, null, lmb.Security, null), MethodName); } }
        public static PositionGrouping.Function GroupByFund { get { return new PositionGrouping.Function((pos, lmb) => new PositionGrouping(null, lmb.Fund, null, null), MethodName); } }
        public static PositionGrouping.Function GroupByFundSecurity { get { return new PositionGrouping.Function((pos, lmb) => new PositionGrouping(null, lmb.Fund, lmb.Security, null), MethodName); } }
        public static PositionGrouping.Function GroupByFundUnderlyer { get { return new PositionGrouping.Function((pos, lmb) => new PositionGrouping(null, lmb.Fund, null, lmb.Security.UnderlyingSecurity), MethodName); } }
        public static PositionGrouping.Function GroupBySecurity { get { return new PositionGrouping.Function((pos, lmb) => new PositionGrouping(null, null, lmb.Security, null), MethodName); } }
        public static PositionGrouping.Function GroupByUnderlyer { get { return new PositionGrouping.Function((pos, lmb) => new PositionGrouping(PositionGrouping.Empty, null, null, null, lmb.Security.UnderlyingSecurity), ); } }

        public static string? MethodName => new StackTrace().GetFrame(1)?.GetMethod()?.Name ?? throw new ArgumentOutOfRangeException("Unable to get MethodName from StackTrace().GetFrame(1)?.GetMethod()?.Name. Consider outputting details.");

        private readonly string _key;
        private readonly DateTime? _date;
        private readonly IFund? _fund;
        private readonly ISecurity? _security;
        private readonly ISecurity? _underlyer;
        private readonly string? _sector; //NOTE: should be IClassification
        private readonly string? _industry;
        private readonly string? _country;
        private readonly string? _region;
        private readonly string? _currency;

        private readonly bool? _isLong;
        private readonly ISecurity? _factor;

        public static readonly PositionGrouping Empty = new PositionGrouping(string.Empty);

        public PositionGrouping(DateTime? date = null, IFund? fund = null, ISecurity? security = null, ISecurity? underlyer = null,
            string? sector = null, string? industry = null, string? country = null, string? region = null, string? currency = null,
            bool? isLong = null, ISecurity? factor = null)
            : this(null, date, fund, security, underlyer, sector, industry, country, region, currency, isLong, factor)
        {

        }

        public PositionGrouping(PositionGrouping? positionGroupBy, DateTime? date = null, IFund? fund = null, ISecurity? security = null, ISecurity? underlyer = null,
            string? sector = null, string? industry = null, string? country = null, string? region = null, string? currency = null, bool? isLong = null, ISecurity? factor = null)
            : this(GetKey(date, fund, security, underlyer, sector, industry, country, region, currency, isLong, factor))
        {
            if (positionGroupBy == null)
            {
                positionGroupBy = PositionGrouping.Empty;
            }

            _date = date ?? positionGroupBy.Date;
            _fund = fund ?? positionGroupBy.Fund;
            _security = security ?? positionGroupBy.Security;
            _underlyer = underlyer ?? positionGroupBy.Underlyer;

            _sector = sector ?? positionGroupBy.Sector;
            _industry = industry ?? positionGroupBy.Industry;
            _country = country ?? positionGroupBy.Country;
            _region = region ?? positionGroupBy.Region;
            _currency = currency ?? positionGroupBy.Currency;

            _isLong = isLong ?? positionGroupBy.IsLong;
            _factor = factor ?? positionGroupBy.Factor;
        }

        public PositionGrouping(string key)
        {
            _key = key; //NOTE: need to use the explicit groupings because you need the objects OR string display names
        }

        public static string GetKey(DateTime? date = null, IFund? fund = null, ISecurity? security = null, ISecurity? underlyer = null,
            string? sector = null, string? industry = null, string? country = null, string? region = null, string? currency = null,
            bool? isLong = null, ISecurity? factor = null)
        {
            //string key = string.Format("Date={0}&Fund={1}&Security={2}&Underlyer={3}&Sector={4}&Industry={5}&Country={6}&Region={7}&Currency={8}",
            //    date == null ? string.Empty : date.Value.ToShortDateString(),
            //    fund == null ? string.Empty : fund.Id.ToString(),
            //    security == null ? string.Empty : security.Id.ToString(),
            //    underlyer == null ? string.Empty : underlyer.Id.ToString(),
            //    sector ?? string.Empty,
            //    industry ?? string.Empty,
            //    country ?? string.Empty,
            //    region ?? string.Empty,
            //    currency ?? string.Empty
            //    );
            string key = "Date=" + (date ?? default(DateTime)).ToString("yyyyMMdd")
                + "&Fund=" + (fund ?? DataModels.PositionData.Fund.Null).Id
                + "&Security=" + (security ?? DataModels.SecurityMaster.Security.Null).Name
                + "&Underlyer=" + (underlyer ?? DataModels.SecurityMaster.Security.Null).Name
                + "&Sector=" + (sector ?? string.Empty) //GicsId.Empty).Id
                + "&Industry=" + (industry ?? string.Empty) //GicsId.Empty).Id
                + "&Country=" + (country ?? string.Empty)
                + "&Region=" + (region ?? string.Empty)
                + "&Currency=" + (currency ?? string.Empty)
                + "&IsLong=" + (isLong ?? default(bool)).ToString()
                + "&Factor=" + (factor ?? DataModels.SecurityMaster.Security.Null).Id;
            return key;
        }

        public DateTime? Date { get { return _date; } }
        public IFund? Fund { get { return _fund; } }
        public ISecurity? Security { get { return _security; } }
        public ISecurity? Underlyer { get { return _underlyer; } }

        public string? Sector { get { return _sector; } }
        public string? Industry { get { return _industry; } }
        public string? Country { get { return _country; } }
        public string? Region { get { return _region; } }
        public string? Currency { get { return _currency; } }

        public bool? IsLong { get { return _isLong; } }
        public ISecurity? Factor { get { return _factor; } }

        public string Key { get { return _key; } }

        public override int GetHashCode()
        {
            return _key.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            PositionGrouping? parameter = obj as PositionGrouping;
            if (parameter == null) return false;
            return _key == parameter._key;
        }

        public int CompareTo(PositionGrouping? other)
        {
            return _key.CompareTo(other?._key);
        }

        public override string ToString()
        {
            return _key;
        }
    }
}
