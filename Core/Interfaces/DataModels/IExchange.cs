namespace Core.Interfaces.DataModels
{
    public interface IExchange : INameable
    {
        string Description { get; }

        ICountry? Country { get; }
    }
}
