namespace Core.Interfaces.DataModels
{
    public interface ITarget
    {
        IUser User { get; }
        IFund Fund { get; }
        ISecurity Security { get; }
        string Formula { get; }
        double? Value { get; }
        DateTime? Date { get; }
        string Notes { get; }
        double? OriginalValue { get; }
        DateTime CreateDateTime { get; }
    }
}
