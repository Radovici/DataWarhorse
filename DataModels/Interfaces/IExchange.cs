namespace DataModels.Interfaces
{
    public interface IExchange : INameable
    {
        string Description { get; set; }

        ICountry? Country { get; }
    }
}
