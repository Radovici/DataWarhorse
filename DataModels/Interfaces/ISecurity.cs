using DataModels.SecurityMaster;

namespace DataModels.Interfaces
{
    public interface ISecurity : INameable
    {
        ISecurity? UnderlyingSecurity { get; }

        SecurityType SecurityType { get; }

        string Symbol { get; }

        double Multiplier { get; }

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

        ICollection<ISecurityAttribute> SecurityAttributes { get; }
    }
}
