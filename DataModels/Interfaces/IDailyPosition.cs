namespace DataModels.Interfaces
{
    public interface IDailyPosition : IPosition
    {
        DateTime? Date { get; }
        IFund? Fund { get; }
        ISecurity? Security { get; }
        IEnumerable<ITrade>? Trades { get; }
        double StartQuantity { get; }
        double EndQuantity { get; }
        bool IsLong { get; }
    }

    public interface IStressedDailyPosition
    {

    }

    public interface IFactoredDailyPosition
    {
        ISecurity Factor { get; }
    }

    public interface IBackcastedDailyPosition
    {

    }
}
