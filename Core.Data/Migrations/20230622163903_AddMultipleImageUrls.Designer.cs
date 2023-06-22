﻿// <auto-generated />
using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Core.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230622163903_AddMultipleImageUrls")]
    partial class AddMultipleImageUrls
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Hotel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Latitude", "Longitude")
                        .IsUnique();

                    b.ToTable("Hotel");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Latitude = 55.167137f,
                            Longitude = 61.379574f
                        },
                        new
                        {
                            Id = 2L,
                            Latitude = 55.16725f,
                            Longitude = 61.395924f
                        },
                        new
                        {
                            Id = 3L,
                            Latitude = 55.161903f,
                            Longitude = 61.43048f
                        });
                });

            modelBuilder.Entity("Core.Entities.Room", b =>
                {
                    b.Property<long>("HotelId")
                        .HasColumnType("bigint");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.Property<string[]>("ImageUrls")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("HotelId", "Number");

                    b.ToTable("Room");

                    b.HasData(
                        new
                        {
                            HotelId = 1L,
                            Number = 1,
                            Class = "Luxe",
                            Floor = 1,
                            ImageUrls = new[] { "https://loremflickr.com/320/240?lock=189138406", "https://loremflickr.com/320/240?lock=27174788", "https://loremflickr.com/320/240?lock=1544873238" },
                            Price = 9999m,
                            State = "Clean"
                        },
                        new
                        {
                            HotelId = 1L,
                            Number = 2,
                            Class = "Default",
                            Floor = 1,
                            ImageUrls = new[] { "https://loremflickr.com/320/240?lock=1851191940", "https://loremflickr.com/320/240?lock=399730367", "https://loremflickr.com/320/240?lock=573170156", "https://loremflickr.com/320/240?lock=1132734020", "https://loremflickr.com/320/240?lock=790063001" },
                            Price = 301m,
                            State = "Clean"
                        },
                        new
                        {
                            HotelId = 1L,
                            Number = 3,
                            Class = "VIP",
                            Floor = 1,
                            ImageUrls = new[] { "https://loremflickr.com/320/240?lock=1639224297" },
                            Price = 1m,
                            State = "Clean"
                        },
                        new
                        {
                            HotelId = 2L,
                            Number = 100,
                            Class = "Default",
                            Floor = 1,
                            ImageUrls = new[] { "https://loremflickr.com/320/240?lock=1380156770", "https://loremflickr.com/320/240?lock=487483428", "https://loremflickr.com/320/240?lock=2034697242", "https://loremflickr.com/320/240?lock=64901873" },
                            Price = 301m,
                            State = "Clean"
                        },
                        new
                        {
                            HotelId = 2L,
                            Number = 101,
                            Class = "Luxe",
                            Floor = 1,
                            ImageUrls = new[] { "https://loremflickr.com/320/240?lock=836161306" },
                            Price = 100m,
                            State = "Clean"
                        },
                        new
                        {
                            HotelId = 2L,
                            Number = 200,
                            Class = "Default",
                            Floor = 2,
                            ImageUrls = new[] { "https://loremflickr.com/320/240?lock=468905345" },
                            Price = 301m,
                            State = "Clean"
                        },
                        new
                        {
                            HotelId = 2L,
                            Number = 201,
                            Class = "Default",
                            Floor = 2,
                            ImageUrls = new[] { "https://loremflickr.com/320/240?lock=122338698", "https://loremflickr.com/320/240?lock=1515236549", "https://loremflickr.com/320/240?lock=590212116", "https://loremflickr.com/320/240?lock=67448649", "https://loremflickr.com/320/240?lock=388649953" },
                            Price = 301m,
                            State = "Clean"
                        },
                        new
                        {
                            HotelId = 3L,
                            Number = 10,
                            Class = "Luxe",
                            Floor = 1,
                            ImageUrls = new[] { "https://loremflickr.com/320/240?lock=851616216" },
                            Price = 1111m,
                            State = "Clean"
                        },
                        new
                        {
                            HotelId = 3L,
                            Number = 11,
                            Class = "Default",
                            Floor = 1,
                            ImageUrls = new[] { "https://loremflickr.com/320/240?lock=644412431", "https://loremflickr.com/320/240?lock=1373935383", "https://loremflickr.com/320/240?lock=1012521378", "https://loremflickr.com/320/240?lock=2054292510" },
                            Price = 301m,
                            State = "Clean"
                        },
                        new
                        {
                            HotelId = 3L,
                            Number = 12,
                            Class = "Default",
                            Floor = 1,
                            ImageUrls = new[] { "https://loremflickr.com/320/240?lock=1794507171" },
                            Price = 301m,
                            State = "Clean"
                        },
                        new
                        {
                            HotelId = 3L,
                            Number = 20,
                            Class = "VIP",
                            Floor = 2,
                            ImageUrls = new[] { "https://loremflickr.com/320/240?lock=750884345" },
                            Price = 675656m,
                            State = "Clean"
                        },
                        new
                        {
                            HotelId = 3L,
                            Number = 21,
                            Class = "VIP",
                            Floor = 2,
                            ImageUrls = new[] { "https://loremflickr.com/320/240?lock=620724332", "https://loremflickr.com/320/240?lock=2087698577", "https://loremflickr.com/320/240?lock=2116665496", "https://loremflickr.com/320/240?lock=1233713347" },
                            Price = 19222m,
                            State = "Clean"
                        },
                        new
                        {
                            HotelId = 3L,
                            Number = 22,
                            Class = "Luxe",
                            Floor = 2,
                            ImageUrls = new[] { "https://loremflickr.com/320/240?lock=1792191646", "https://loremflickr.com/320/240?lock=499288552", "https://loremflickr.com/320/240?lock=381462456" },
                            Price = 1m,
                            State = "Clean"
                        });
                });

            modelBuilder.Entity("Core.Entities.RoomModifier", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RoomModifier");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Двуспальная кровать"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Односпальная кровать"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Питание включено"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Питание не включено"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Сейф есть"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Сейфа нет"
                        });
                });

            modelBuilder.Entity("RoomRoomModifier", b =>
                {
                    b.Property<long>("RoomModifiersId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoomsHotelId")
                        .HasColumnType("bigint");

                    b.Property<int>("RoomsNumber")
                        .HasColumnType("integer");

                    b.HasKey("RoomModifiersId", "RoomsHotelId", "RoomsNumber");

                    b.HasIndex("RoomsHotelId", "RoomsNumber");

                    b.ToTable("RoomRoomModifier", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Room", b =>
                {
                    b.HasOne("Core.Entities.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("RoomRoomModifier", b =>
                {
                    b.HasOne("Core.Entities.RoomModifier", null)
                        .WithMany()
                        .HasForeignKey("RoomModifiersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsHotelId", "RoomsNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Hotel", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
