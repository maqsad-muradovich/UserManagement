namespace UserManagment.Services
{
    public interface IUserService
    {
        void AddCredential(string username, string password);
        bool Login(string username, string password);
    }
}
