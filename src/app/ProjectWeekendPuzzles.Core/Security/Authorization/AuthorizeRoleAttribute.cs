using System;

namespace ProjectWeekendPuzzles.Core.Security.Authorization
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AuthorizeRoleAttribute : Attribute
    {
        public AuthorizeRoleAttribute(string role)
        {
            Role = role;
        }

        public string Role { get; }
    }
}
