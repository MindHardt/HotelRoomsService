using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.EntityConfigurations;

public class HotelEntityConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Rooms)
            .WithOne(x => x.Hotel)
            .HasForeignKey(x => x.HotelId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.Latitude, x.Longitude})
            .IsUnique();
        
        // Данные по умолчанию для тестов
        var radisson = new Hotel
        {
            Id = 1,
            Latitude = 55.167138f,
            Longitude = 61.379575f,
        };
        var malachite = new Hotel
        {
            Id = 2,
            Latitude = 55.167251f,
            Longitude = 61.395924f
        };
        var vidgof = new Hotel
        {
            Id = 3,
            Latitude = 55.161903f,
            Longitude = 61.430482f
        };

        builder.HasData(radisson, malachite, vidgof);

    }
}