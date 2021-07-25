using System;

namespace ProjectWeekendPuzzles.Security.Authentication
{
    public class UserCredentials
    {
        public UserCredentials(string name, string password)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public string Name { get; }
        public string Password { get; }
    }
}
