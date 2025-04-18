namespace Core.Interfaces.DataModels
{
    public interface ICountry : INameable
    {
        ICurrency? Currency { get; }
    }
}
