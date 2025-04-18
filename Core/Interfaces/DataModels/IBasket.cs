namespace Core.Interfaces.DataModels
{
    public interface IBasket
    {
        IEnumerable<ISecurity> Securities { get; }
    }
}
