namespace Metro2036.Data
{
    using Microsoft.EntityFrameworkCore;
    using Metro2036.Data.EntityConfiguration;
    using Metro2036.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class Metro2036DbContext : IdentityDbContext<User>
    {
        public Metro2036DbContext(DbContextOptions<Metro2036DbContext> options)
            : base(options)
        {
        }

        public DbSet<Station> Stations { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<RouteStation> RouteStations { get; set; }
        public DbSet<Train> Trains { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<TravelLog> TravelLogs { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StationConfiguration());
            builder.ApplyConfiguration(new RouteConfiguration());
            builder.ApplyConfiguration(new PointConfiguration());
            builder.ApplyConfiguration(new RouteStationConfiguration());
            builder.ApplyConfiguration(new TrainConfiguration());
            //builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new TravelLogConfiguration());
            builder.ApplyConfiguration(new FeedbackConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
