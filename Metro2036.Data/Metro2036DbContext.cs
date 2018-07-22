namespace Metro2036.Data
{
    using Microsoft.EntityFrameworkCore;
    using Metro2036.Data.EntityConfiguration;
    using Metro2036.Models;

    public class Metro2036DbContext : DbContext
    {
        public Metro2036DbContext(DbContextOptions<Metro2036DbContext> options)
            : base(options)
        {
        }

        //public Metro2036DbContext(DbContextOptions options) : base(options)
        //{
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    if (!builder.IsConfigured)
        //    {
        //        builder.UseSqlServer(Configuration.ConnectionString);
        //    }
        //}

        public DbSet<Station> Stations { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<RouteStation> RouteStations { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StationConfiguration());
            builder.ApplyConfiguration(new RouteConfiguration());
            builder.ApplyConfiguration(new PointConfiguration());
            builder.ApplyConfiguration(new RouteStationConfiguration());
            builder.ApplyConfiguration(new TrainConfiguration());
            builder.ApplyConfiguration(new PassengerConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
