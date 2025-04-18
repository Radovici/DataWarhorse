namespace Core.Interfaces.DataModels
{
    public interface IOption : ISecurity
    {
        DateTime ExpirationDate { get; }
        double StrikePrice { get; }
        bool IsCall { get; }
    }
}
