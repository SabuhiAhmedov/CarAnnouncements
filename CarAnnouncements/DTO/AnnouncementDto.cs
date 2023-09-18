using CarAnnouncements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CarAnnouncements.DTO
{
    public class AnnouncementDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
        public int Distance { get; set; }
        public int EngineVolume { get; set; }
        public int BanId { get; set; }
        public int ColorId { get; set; }
        public int GasId { get; set; }
        public int GearBoxId { get; set; }
        public int ModelId { get; set; }
        public int MarkId { get; set; }
        public List<int> ImagesId { get; set; }




    }
}
