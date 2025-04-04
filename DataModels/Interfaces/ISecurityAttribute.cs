namespace DataModels.Interfaces
{
    public interface ISecurityAttribute : IDatedNameValuePair<string>
    {
        int SecurityId { get; }

        ISecurity Security { get; }
    }
}
