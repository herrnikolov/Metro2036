namespace Metro2036.Data.EntityConfiguration
{
    using Metro2036.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class RouteStationConfiguration : IEntityTypeConfiguration<RouteStation>
    {
        public void Configure(EntityTypeBuilder<RouteStation> builder)
        {
            builder.HasKey(r => new { r.RouteId, r.StationId });

        }
    }
}