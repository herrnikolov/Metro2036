namespace Metro2036.Web
{
    public class WebConstants
    {
        //Admin User Seeding
        public const string AdministratorArea = "Admin";
        public const string AdministratorRole = "Admin";
        public const string AdminEmail = "admin@metro2036.com";
        public const string AdminUserName = "admin@metro2036.com";
        public const string AdminPassword = "P@ssw0rd";

        //User Seeding
        public const string UserArea = "User";
        public const string UserRole = "User";
        public const string UserPassword = "P@ssw0rd";

        // Tables Seeding Paths
        public const string UsersListPath = @"wwwroot\seedfiles\users.json";
        public const string StationsListPath = @"wwwroot\seedfiles\metro_stations.json";
        public const string RoutesListPath = @"wwwroot\seedfiles\routes.json";
        public const string TrainsListPath = @"wwwroot\seedfiles\trains.json";
        public const string TravelLogsListPath = @"wwwroot\seedfiles\travellog.json";
        
    }
}
