namespace Core.Interfaces.DataModels
{
    public interface ISecurity : INameable
    {
        int Id { get; }

        ISecurity? UnderlyingSecurity { get; }

        ISecurityType SecurityType { get; } // TODO: should also be an interface

        string Symbol { get; }

        double Multiplier { get; }

        // NOTE: this was DW's 2019 codebase; commented out for the time-being.
        //SortedDictionary<DateOnly, IPrice> Prices { get; }
        //SortedDictionary<DateOnly, double> Returns { get; }
        //SortedDictionary<DateOnly, IEquitySplit> Splits { get; }

        //bool IsOption { get; }
        //bool IsEquity { get; }
        //bool IsEquityOption { get; }

        //double Beta { get; }
        DateOnly StartDate { get; } // NOTE: IpoDate is a better name, but this is consistent with the rest of the codebase
        DateOnly EndDate { get; }
        //string Sector { get; }
        //string Industry { get; }
        //string Country { get; }
        //string Region { get; }

        ICurrency Currency { get; }

        IExchange Exchange { get; }

        IEnumerable<ISecurityAttribute> SecurityAttributes { get; }
    }
}
