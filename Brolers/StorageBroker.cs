using System;
using System.IO;

namespace UserManagment.Brokers
{
    public class StorageBroker : IStorageBroker
    {
        private const string DataFilePath = "Assets/credentials.txt";

        public void AddUserData(string username, string password)
        {
            using (StreamWriter writer = File.AppendText(DataFilePath))
            {
                writer.WriteLine($"{username}:{password}");
            }
        }

        public bool ValidateUser(string username, string password)
        {
            if (File.Exists(DataFilePath))
            {
                using (StreamReader reader = File.OpenText(DataFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(':');
                        if (parts.Length == 2 && parts[0] == username && parts[1] == password)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
