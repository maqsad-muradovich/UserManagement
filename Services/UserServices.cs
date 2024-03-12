using System;
using UserManagment.Brokers;

namespace UserManagment.Services
{
    public class UserService : IUserService
    {
        private readonly IStorageBroker _storageBroker;

        public UserService(IStorageBroker storageBroker)
        {
            _storageBroker = storageBroker;
        }

        public void AddCredential(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty");
            }

            _storageBroker.AddUserData(username, password);
        }

        public bool Login(string username, string password)
        {
            return _storageBroker.ValidateUser(username, password);
        }
    }
}