namespace Core.Interfaces.DataModels
{
    public interface INameValuePair<T> // TODO: consider renaming this to IDatedKeyValue
    {
        string Name { get; }

        T Value { get; }
    }
}
