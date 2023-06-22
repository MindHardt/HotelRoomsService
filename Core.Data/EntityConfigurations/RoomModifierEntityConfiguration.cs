using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.EntityConfigurations;

public class RoomModifierEntityConfiguration : IEntityTypeConfiguration<RoomModifier>
{
    public void Configure(EntityTypeBuilder<RoomModifier> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsUnicode();
        builder.HasMany(r => r.Rooms)
            .WithMany(m => m.RoomModifiers)
            .UsingEntity(e => e.ToTable("RoomRoomModifier"));

        var mods = new RoomModifier[]
        {
            new() { Id = 1, Name = "Двуспальная кровать"},
            new() { Id = 2, Name = "Односпальная кровать" },
            new() { Id = 3, Name = "Питание включено" },
            new() { Id = 4, Name = "Питание не включено" },
            new() { Id = 5, Name = "Сейф есть" },
            new() { Id = 6, Name = "Сейфа нет" },
        };

        builder.HasData(mods);
    }
}
