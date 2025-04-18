namespace Core.Interfaces.DataModels
{
    public interface IDatedNameValuePair<T> : INameValuePair<T> // TODO: consider renaming this to IDatedKeyValue
    {
        DateOnly Date { get; }
    }
}
