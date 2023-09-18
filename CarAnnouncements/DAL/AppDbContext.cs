using CarAnnouncements.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAnnouncements.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Ban> Bans { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Gas> Gases { get; set; }
        public DbSet<GearBox> GearBoxes { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
          

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ban>().HasData(
                new Ban { Id = 1, Type = "Avtobus" },
                new Ban { Id = 2, Type = "Dartqı" },
                new Ban { Id = 3, Type = "Furqon" },
                new Ban { Id = 4, Type = "Hetçbek" },
                new Ban { Id = 5, Type = "Karvan" },
                new Ban { Id = 6, Type = "Kabriolet" },
                new Ban { Id = 7, Type = "Liftbek" },
                new Ban { Id = 8, Type = "Sedan" }
                );
            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Type = "Qara" },
                new Color { Id = 2, Type = "Boz" },
                new Color { Id = 3, Type = "Yaş Asfalt" },
                new Color { Id = 4, Type = "Qırmızı" },
                new Color { Id = 5, Type = "Ağ" },
                new Color { Id = 6, Type = "Gümüşü" },
                new Color { Id = 7, Type = "Yaşıl" },
                new Color { Id = 8, Type = "Mavi" }

                );
            modelBuilder.Entity<Gas>().HasData(
                new Gas { Id = 1, Type = "Benzin" },
                new Gas { Id = 2, Type = "Dizel" },
                new Gas { Id = 3, Type = "Qaz" },
                new Gas { Id = 4, Type = "Elektiro" },
                new Gas { Id = 5, Type = "Hibrid" },
                new Gas { Id = 6, Type = "Plug-in Hibrid" }
                );
            modelBuilder.Entity<GearBox>().HasData(
                new GearBox { Id = 1, Type = "Mexaniki" },
                new GearBox { Id = 2, Type = "Avtomat" },
                new GearBox { Id = 3, Type = "Robotlaştırılmış" },
                new GearBox { Id = 4, Type = "Variator" }
                );
            modelBuilder.Entity<Mark>().HasData(
                new Mark { Id = 1, Type = "Dodge" },
                new Mark { Id = 2, Type = "Audi" },
                new Mark { Id = 3, Type = "BMW" },
                new Mark { Id = 4, Type = "Fiat" },
                new Mark { Id = 5, Type = "Ford" },
                new Mark { Id = 6, Type = "Ferrari" },
                new Mark { Id = 7, Type = "Mercedes" },
                new Mark { Id = 8, Type = "Toyota" },
                new Mark { Id = 9, Type = "Tesla" },
                new Mark { Id = 10, Type = "Volkswagen" }

                );
            modelBuilder.Entity<Model>().HasData(
                new Model { Id = 1, Type = "Dart", MarkId = 1 },
                new Model { Id = 2, Type = "Dakota", MarkId = 1 },
                new Model { Id = 3, Type = "Durango", MarkId = 1 },

                new Model { Id = 4, Type = "A1", MarkId = 2 },
                new Model { Id = 5, Type = "A2", MarkId = 2 },
                new Model { Id = 6, Type = "A3", MarkId = 2 },

                new Model { Id = 7, Type = "M3", MarkId = 3 },
                new Model { Id = 8, Type = "M4", MarkId = 3 },
                new Model { Id = 9, Type = "M5", MarkId = 3 },

                new Model { Id = 10, Type = "Bravo", MarkId = 4 },
                new Model { Id = 11, Type = "Coupe", MarkId = 4 },
                new Model { Id = 12, Type = "Croma", MarkId = 4 },

                new Model { Id = 13, Type = "Focus", MarkId = 5 },
                new Model { Id = 14, Type = "Mustang", MarkId = 5 },
                new Model { Id = 15, Type = "Tempo", MarkId = 5 },

                new Model { Id = 16, Type = "296 GTB", MarkId = 6 },
                new Model { Id = 17, Type = "458 Spider", MarkId = 6},
                new Model { Id = 18, Type = "Enzo", MarkId = 6 },

                new Model { Id = 19, Type = "190", MarkId = 7 },
                new Model { Id = 20, Type = "AMG GT", MarkId = 7 },
                new Model { Id = 21, Type = "CLK 240", MarkId = 7 },

                new Model { Id = 22, Type = "Prius", MarkId = 8 },
                new Model { Id = 23, Type = "Camry", MarkId = 8 },
                new Model { Id = 24, Type = "Supra", MarkId = 8 },

                new Model { Id = 25, Type = "Cybertruck", MarkId = 9 },
                new Model { Id = 26, Type = "Roadster", MarkId = 9 },
                new Model { Id = 27, Type = "Model X", MarkId = 9 },

                new Model { Id = 28, Type = "Rabbit", MarkId = 10 },
                new Model { Id = 29, Type = "Taos", MarkId = 10 },
                new Model { Id = 30, Type = "Polo", MarkId = 10});

        }
       


    }
}
