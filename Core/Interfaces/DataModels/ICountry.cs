namespace DataModels.Interfaces
{
    public interface ICountry : INameable
    {
        ICurrency? Currency { get; }
    }
}
