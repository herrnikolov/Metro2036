namespace Metro2036.Data.EntityConfiguration
{
    using Metro2036.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class TravelLogConfiguration : IEntityTypeConfiguration<TravelLog>
    {
        public void Configure(EntityTypeBuilder<TravelLog> builder)
        {
            builder.HasKey(tl => tl.Id);

            builder.HasOne(tl => tl.Station)
                .WithMany(s => s.TravelLogs)
                .HasForeignKey(tl => tl.StationId);

            builder.HasOne(tl => tl.User)
                .WithMany(s => s.Travels)
                .HasForeignKey(tl => tl.UserId);
        }
    }
}
