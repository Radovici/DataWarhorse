namespace Core.Interfaces.DataModels
{
    public interface IEquitySplit // NOTE: is this applicable to non-equities, i.e., ISplit?
    {
        int SecurityId { get; }
        DateOnly Date { get; }
        double Ratio { get; }
    }
}
