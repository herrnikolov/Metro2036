namespace Metro2036.Data.EntityConfiguration
{
    using Metro2036.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PointConfiguration : IEntityTypeConfiguration<Point>
    {
        public void Configure(EntityTypeBuilder<Point> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Latitude)
                .HasColumnType("decimal(18,6)")
                .IsRequired();

            builder.Property(p => p.Longitude)
                .HasColumnType("decimal(18,6)")
                .IsRequired();
        }
    }
}