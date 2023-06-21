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
        
        // Данные по умолчанию для тестов
        var radisson = new Hotel
        {
            Id = 1,
            Name = "RadissonBlu",
            Address = "Улица Труда, 179, Челябинск, 454080",
            Coordinates = new HotelCoordinates(55.167138, 61.379575)
        };
        var malachite = new Hotel
        {
            Id = 2,
            Name = "Малахит",
            Address = "Улица Труда, 153, Челябинск, 454091",
            Coordinates = new HotelCoordinates(55.167251, 61.395924)
        };
        var vidgof = new Hotel
        {
            Id = 3,
            Name = "Гранд отель Видгоф",
            Address = "Проспект Ленина, 26А, Челябинск, 454007",
            Coordinates = new HotelCoordinates(55.161913, 61.431345)
        };

        builder.HasData(radisson, malachite, vidgof);

    }
}