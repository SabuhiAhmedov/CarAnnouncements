﻿// <auto-generated />
using System;
using CarAnnouncements.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarAnnouncements.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230916081424_CreateUsersTable")]
    partial class CreateUsersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarAnnouncements.Models.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BanId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<int>("EngineVolume")
                        .HasColumnType("int");

                    b.Property<int>("GasId")
                        .HasColumnType("int");

                    b.Property<int>("GearBoxId")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BanId");

                    b.HasIndex("ColorId");

                    b.HasIndex("GasId");

                    b.HasIndex("GearBoxId");

                    b.HasIndex("ModelId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("CarAnnouncements.Models.Ban", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Avtobus"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Dartqı"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Furqon"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Hetçbek"
                        },
                        new
                        {
                            Id = 5,
                            Type = "Karvan"
                        },
                        new
                        {
                            Id = 6,
                            Type = "Kabriolet"
                        },
                        new
                        {
                            Id = 7,
                            Type = "Liftbek"
                        },
                        new
                        {
                            Id = 8,
                            Type = "Sedan"
                        });
                });

            modelBuilder.Entity("CarAnnouncements.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Qara"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Boz"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Yaş Asfalt"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Qırmızı"
                        },
                        new
                        {
                            Id = 5,
                            Type = "Ağ"
                        },
                        new
                        {
                            Id = 6,
                            Type = "Gümüşü"
                        },
                        new
                        {
                            Id = 7,
                            Type = "Yaşıl"
                        },
                        new
                        {
                            Id = 8,
                            Type = "Mavi"
                        });
                });

            modelBuilder.Entity("CarAnnouncements.Models.Gas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gases");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Benzin"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Dizel"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Qaz"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Elektiro"
                        },
                        new
                        {
                            Id = 5,
                            Type = "Hibrid"
                        },
                        new
                        {
                            Id = 6,
                            Type = "Plug-in Hibrid"
                        });
                });

            modelBuilder.Entity("CarAnnouncements.Models.GearBox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GearBoxes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Mexaniki"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Avtomat"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Robotlaştırılmış"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Variator"
                        });
                });

            modelBuilder.Entity("CarAnnouncements.Models.Images", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnnouncementId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnnouncementId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("CarAnnouncements.Models.Mark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Dodge"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Audi"
                        },
                        new
                        {
                            Id = 3,
                            Type = "BMW"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Fiat"
                        },
                        new
                        {
                            Id = 5,
                            Type = "Ford"
                        },
                        new
                        {
                            Id = 6,
                            Type = "Ferrari"
                        },
                        new
                        {
                            Id = 7,
                            Type = "Mercedes"
                        },
                        new
                        {
                            Id = 8,
                            Type = "Toyota"
                        },
                        new
                        {
                            Id = 9,
                            Type = "Tesla"
                        },
                        new
                        {
                            Id = 10,
                            Type = "Volkswagen"
                        });
                });

            modelBuilder.Entity("CarAnnouncements.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MarkId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MarkId");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MarkId = 1,
                            Type = "Dart"
                        },
                        new
                        {
                            Id = 2,
                            MarkId = 1,
                            Type = "Dakota"
                        },
                        new
                        {
                            Id = 3,
                            MarkId = 1,
                            Type = "Durango"
                        },
                        new
                        {
                            Id = 4,
                            MarkId = 2,
                            Type = "A1"
                        },
                        new
                        {
                            Id = 5,
                            MarkId = 2,
                            Type = "A2"
                        },
                        new
                        {
                            Id = 6,
                            MarkId = 2,
                            Type = "A3"
                        },
                        new
                        {
                            Id = 7,
                            MarkId = 3,
                            Type = "M3"
                        },
                        new
                        {
                            Id = 8,
                            MarkId = 3,
                            Type = "M4"
                        },
                        new
                        {
                            Id = 9,
                            MarkId = 3,
                            Type = "M5"
                        },
                        new
                        {
                            Id = 10,
                            MarkId = 4,
                            Type = "Bravo"
                        },
                        new
                        {
                            Id = 11,
                            MarkId = 4,
                            Type = "Coupe"
                        },
                        new
                        {
                            Id = 12,
                            MarkId = 4,
                            Type = "Croma"
                        },
                        new
                        {
                            Id = 13,
                            MarkId = 5,
                            Type = "Focus"
                        },
                        new
                        {
                            Id = 14,
                            MarkId = 5,
                            Type = "Mustang"
                        },
                        new
                        {
                            Id = 15,
                            MarkId = 5,
                            Type = "Tempo"
                        },
                        new
                        {
                            Id = 16,
                            MarkId = 6,
                            Type = "296 GTB"
                        },
                        new
                        {
                            Id = 17,
                            MarkId = 6,
                            Type = "458 Spider"
                        },
                        new
                        {
                            Id = 18,
                            MarkId = 6,
                            Type = "Enzo"
                        },
                        new
                        {
                            Id = 19,
                            MarkId = 7,
                            Type = "190"
                        },
                        new
                        {
                            Id = 20,
                            MarkId = 7,
                            Type = "AMG GT"
                        },
                        new
                        {
                            Id = 21,
                            MarkId = 7,
                            Type = "CLK 240"
                        },
                        new
                        {
                            Id = 22,
                            MarkId = 8,
                            Type = "Prius"
                        },
                        new
                        {
                            Id = 23,
                            MarkId = 8,
                            Type = "Camry"
                        },
                        new
                        {
                            Id = 24,
                            MarkId = 8,
                            Type = "Supra"
                        },
                        new
                        {
                            Id = 25,
                            MarkId = 9,
                            Type = "Cybertruck"
                        },
                        new
                        {
                            Id = 26,
                            MarkId = 9,
                            Type = "Roadster"
                        },
                        new
                        {
                            Id = 27,
                            MarkId = 9,
                            Type = "Model X"
                        },
                        new
                        {
                            Id = 28,
                            MarkId = 10,
                            Type = "Rabbit"
                        },
                        new
                        {
                            Id = 29,
                            MarkId = 10,
                            Type = "Taos"
                        },
                        new
                        {
                            Id = 30,
                            MarkId = 10,
                            Type = "Polo"
                        });
                });

            modelBuilder.Entity("CarAnnouncements.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarAnnouncements.Models.Announcement", b =>
                {
                    b.HasOne("CarAnnouncements.Models.Ban", "Ban")
                        .WithMany("Announcements")
                        .HasForeignKey("BanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarAnnouncements.Models.Color", "Color")
                        .WithMany("Announcements")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarAnnouncements.Models.Gas", "Gas")
                        .WithMany("Announcements")
                        .HasForeignKey("GasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarAnnouncements.Models.GearBox", "GearBox")
                        .WithMany("Announcements")
                        .HasForeignKey("GearBoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarAnnouncements.Models.Model", "Model")
                        .WithMany("Announcements")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ban");

                    b.Navigation("Color");

                    b.Navigation("Gas");

                    b.Navigation("GearBox");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("CarAnnouncements.Models.Images", b =>
                {
                    b.HasOne("CarAnnouncements.Models.Announcement", "Announcement")
                        .WithMany("Images")
                        .HasForeignKey("AnnouncementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Announcement");
                });

            modelBuilder.Entity("CarAnnouncements.Models.Model", b =>
                {
                    b.HasOne("CarAnnouncements.Models.Mark", "Mark")
                        .WithMany("Model")
                        .HasForeignKey("MarkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mark");
                });

            modelBuilder.Entity("CarAnnouncements.Models.Announcement", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("CarAnnouncements.Models.Ban", b =>
                {
                    b.Navigation("Announcements");
                });

            modelBuilder.Entity("CarAnnouncements.Models.Color", b =>
                {
                    b.Navigation("Announcements");
                });

            modelBuilder.Entity("CarAnnouncements.Models.Gas", b =>
                {
                    b.Navigation("Announcements");
                });

            modelBuilder.Entity("CarAnnouncements.Models.GearBox", b =>
                {
                    b.Navigation("Announcements");
                });

            modelBuilder.Entity("CarAnnouncements.Models.Mark", b =>
                {
                    b.Navigation("Model");
                });

            modelBuilder.Entity("CarAnnouncements.Models.Model", b =>
                {
                    b.Navigation("Announcements");
                });
#pragma warning restore 612, 618
        }
    }
}
