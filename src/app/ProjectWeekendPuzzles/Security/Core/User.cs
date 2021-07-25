using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectWeekendPuzzles.Security.Core
{
    public class User
    {
        public User(string name, IEnumerable<string> roles)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Roles = roles ?? throw new ArgumentNullException(nameof(roles));
        }

        public string Name { get; }
        public IEnumerable<string> Roles { get; }
        public static User Anonymous => new User("Anonymous", Enumerable.Empty<string>());
    }
}
