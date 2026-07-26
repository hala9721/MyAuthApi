namespace MyAuth.Domain
{
    public static class AuthRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string Developer = "Developer";
        public const string Manager = "Manager";

        public static readonly string[] AllRoles = [Admin, Manager, Developer, User];
    }
}
