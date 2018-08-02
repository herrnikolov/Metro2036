namespace Metro2036.Web
{
    public class Constants
    {
        //Admin User Seeding
        public const string AdministratorArea = "Admin";
        public const string AdministratorRole = "Admin";
        public const string AdminEmail = "admin@metro2036.com";
        public const string AdminUserName = "admin@metro2036.com";
        public const string AdminPassword = "P@ssw0rd";

        //User Seeding
        public const string UserRole = "Passenger";
        public const string UserPassword = "P@ssw0rd";

        // Tables Seeding Paths
        public const string UsersListPath = @"wwwroot\seedfiles\users.json";


        public const string CostEntryTypesListPath = @"wwwroot\seedfiles\cost-entry-types.json";
        public const string ExtraFuelConsumersListPath = @"wwwroot\seedfiles\extra-fuel-consumers.json";
    }
}
