namespace Core.Interfaces.DataModels
{
    public interface IDailyPosition : IPosition
    {
        DateOnly Date { get; }
        IFund Fund { get; }
        ISecurity Security { get; }
        IEnumerable<ITrade> Trades { get; }
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
