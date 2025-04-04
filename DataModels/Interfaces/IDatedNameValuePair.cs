namespace DataModels.Interfaces
{
    public interface IDatedNameValuePair<T> : INameValuePair<T> // TODO: consider renaming this to IDatedKeyValue
    {
        DateOnly Date { get; }
    }
}
