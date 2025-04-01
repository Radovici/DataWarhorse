namespace DataModels.Interfaces
{
    public interface IEquitySplit // NOTE: is this applicable to non-equities, i.e., ISplit?
    {
        int SecurityId { get; }
        DateTime Date { get; }
        double Ratio { get; }
    }
}
