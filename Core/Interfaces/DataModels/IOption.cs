namespace Core.Interfaces.DataModels
{
    public interface IOption : ISecurity
    {
        DateOnly ExpirationDate { get; }
        double StrikePrice { get; }
        bool IsCall { get; }
    }
}
