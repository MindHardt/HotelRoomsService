using Bogus;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.EntityConfigurations;

public class RoomEntityConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(x => new { x.HotelId, x.Number });
        builder.HasOne(x => x.Hotel)
            .WithMany(x => x.Rooms)
            .HasForeignKey(x => x.HotelId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(r => r.RoomModifiers)
            .WithMany(m => m.Rooms)
            .UsingEntity(e => e.ToTable("RoomRoomModifier"));
        builder.Property(x => x.State)
            .HasConversion<string>();
        builder.Property(x => x.Class)
            .HasConversion<string>();

        // Seeded data
        var rooms = new[]
        {
            new Room { Number = 1, Hotel = null!, HotelId = 1, Class = RoomClass.Luxe, Price = 9999, Floor = 1, ImageUrls = GetImageUrls()},
            new Room { Number = 2, Hotel = null!, HotelId = 1, Class = RoomClass.Default, Price = 301, Floor = 1, ImageUrls = GetImageUrls()},
            new Room { Number = 3, Hotel = null!, HotelId = 1, Class = RoomClass.VIP, Price = 1, Floor = 1, ImageUrls = GetImageUrls()},
            
            new Room { Number = 100, Hotel = null!, HotelId = 2, Class = RoomClass.Default, Price = 301, Floor = 1, ImageUrls = GetImageUrls()},
            new Room { Number = 101, Hotel = null!, HotelId = 2, Class = RoomClass.Luxe, Price = 100, Floor = 1, ImageUrls = GetImageUrls()},
            new Room { Number = 200, Hotel = null!, HotelId = 2, Class = RoomClass.Default, Price = 301, Floor = 2, ImageUrls = GetImageUrls()},
            new Room { Number = 201, Hotel = null!, HotelId = 2, Class = RoomClass.Default, Price = 301, Floor = 2, ImageUrls = GetImageUrls()},
            
            new Room { Number = 10, Hotel = null!, HotelId = 3, Class = RoomClass.Luxe, Price = 1111, Floor = 1, ImageUrls = GetImageUrls()},
            new Room { Number = 11, Hotel = null!, HotelId = 3, Class = RoomClass.Default, Price = 301, Floor = 1, ImageUrls = GetImageUrls()},
            new Room { Number = 12, Hotel = null!, HotelId = 3, Class = RoomClass.Default, Price = 301, Floor = 1, ImageUrls = GetImageUrls()},
            new Room { Number = 20, Hotel = null!, HotelId = 3, Class = RoomClass.VIP, Price = 675656, Floor = 2, ImageUrls = GetImageUrls()},
            new Room { Number = 21, Hotel = null!, HotelId = 3, Class = RoomClass.VIP, Price = 19222, Floor = 2, ImageUrls = GetImageUrls()},
            new Room { Number = 22, Hotel = null!, HotelId = 3, Class = RoomClass.Luxe, Price = 1, Floor = 2, ImageUrls = GetImageUrls()},
        };
        builder.HasData(rooms);
    }

    private string[] GetImageUrls()
    {
        var faker = new Faker();
        return faker.MakeLazy(faker.Random.Int(1, 5), () => faker.Image.LoremFlickrUrl()).ToArray();
    }
}