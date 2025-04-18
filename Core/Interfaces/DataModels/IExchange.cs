namespace DataModels.Interfaces
{
    public interface IExchange : INameable
    {
        string Description { get; }

        ICountry? Country { get; }
    }
}
