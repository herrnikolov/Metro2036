namespace Metro2036.Data.EntityConfiguration
{
    using Metro2036.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class TrainConfiguration : IEntityTypeConfiguration<Train>
    {
        public void Configure(EntityTypeBuilder<Train> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(t => t.Route)
                .WithMany(r => r.Trains)
                .HasForeignKey(t => t.RouteId);
        }
    }
}
