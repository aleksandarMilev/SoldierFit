namespace SoldierFit.Infrastructure.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoldierFit.Infrastructure.Data.Models;
    using SoldierFit.Infrastructure.Data.SeedData;

    public class AthleteConfiguration : IEntityTypeConfiguration<Athlete>
    {
        public void Configure(EntityTypeBuilder<Athlete> builder)
        {
            builder.HasData(DataSeeder.SeedAthletes());
        }
    }
}
