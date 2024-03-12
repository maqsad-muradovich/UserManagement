namespace UserManagment.Brokers
{
    public interface IStorageBroker
    {
        void AddUserData(string username, string password);
        bool ValidateUser(string username, string password);
    }
}
