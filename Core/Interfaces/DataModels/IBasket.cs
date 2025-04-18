namespace DataModels.Interfaces
{
    public interface IBasket
    {
        IEnumerable<ISecurity> Securities { get; }
    }
}
