namespace Eshop.Data.Common.Roles
{
    using System.Collections.Generic;

    public class AppRoles
    {
        public const string ULTIMATE_ROLE = "Ultimate";
        public const string ADMIN_ROLE = "Administrator";
        public const string CLIENT_ROLE = "Client";

        public static readonly HashSet<string> AllRoles = new HashSet<string>()
        {
            ULTIMATE_ROLE,
            ADMIN_ROLE,
            CLIENT_ROLE
        };
    }
}
