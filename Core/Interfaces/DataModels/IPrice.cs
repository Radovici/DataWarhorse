namespace Core.Interfaces.DataModels
{
    public interface IPrice
    {
        ISecurity Security { get; }
        DateOnly Date { get; }
        double Last { get; }
        double Volume { get; }
        DateTime CreateDateTime { get; }
    }
}