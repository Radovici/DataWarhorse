namespace Core.Interfaces.DataModels
{
    public interface ISecurityAttribute : IDatedNameValuePair<string>
    {
        int SecurityId { get; }

        ISecurity Security { get; }
    }
}
