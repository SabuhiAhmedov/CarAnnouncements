using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarAnnouncements.Models
{
    public class Announcement
    {
        public int  Id { get; set; }
      
        public int Price { get; set; }
        public int Year { get; set; }
        public int Distance { get; set; }
        public int EngineVolume { get; set; }
        public Ban Ban { get; set; }
        public int BanId { get; set; }
        public Color Color { get; set; }
        public int ColorId { get; set; }
        public Gas Gas { get; set; }
        public int GasId { get; set; }
        public GearBox GearBox { get; set; }
        public int GearBoxId { get; set; }
        [NotMapped]
        public IFormFile[] Photos { get; set; } 
        public List<Images> Images { get; set; }
        public Model Model { get; set; }
        public int ModelId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        
        

    }
}
