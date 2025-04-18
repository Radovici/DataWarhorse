using DataModels.SecurityMaster;

namespace DataModels.Interfaces
{
    public interface ISecurity : INameable
    {
        int Id { get; }

        ISecurity? UnderlyingSecurity { get; }

        SecurityType SecurityType { get; } // TODO: should also be an interface

        string Symbol { get; }

        double Multiplier { get; }

        // NOTE: this was DW's 2019 codebase; commented out for the time-being.
        //SortedDictionary<DateTime, IPrice> Prices { get; }
        //SortedDictionary<DateTime, double> Returns { get; }
        //SortedDictionary<DateTime, IEquitySplit> Splits { get; }

        //bool IsOption { get; }
        //bool IsEquity { get; }
        //bool IsEquityOption { get; }

        //double Beta { get; }
        //DateTime MaxDate { get; }
        //string Sector { get; }
        //string Industry { get; }
        //string Country { get; }
        //string Region { get; }

        ICurrency Currency { get; }

        IExchange Exchange { get; }

        IEnumerable<ISecurityAttribute> SecurityAttributes { get; }
    }
}
