namespace DataModels.Interfaces
{
    public interface IPrice
    {
        ISecurity Security { get; }
        DateTime Date { get; }
        double Last { get; }
        double Volume { get; }
        DateTime CreateDateTime { get; }
    }
}
