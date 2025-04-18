namespace Core.Interfaces.DataModels
{
    public interface IUser
    {
        public string Name { get; }
        public string Email { get; }
        public string Settings { get; }
    }
}
