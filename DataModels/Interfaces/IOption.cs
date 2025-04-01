namespace DataModels.Interfaces
{
    public interface IOption : ISecurity
    {
        DateTime ExpirationDate { get; }
        double StrikePrice { get; }
        bool IsCall { get; }
    }
}
