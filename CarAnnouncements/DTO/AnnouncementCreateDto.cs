using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarAnnouncements.DTO
{
    public class AnnouncementCreateDto
    {
        [Required]
        public int Price { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Distance { get; set; }
        [Required]
        public int EngineVolume { get; set; }
        [Required]
        public int BanId { get; set; }
        [Required]
        public int ColorId { get; set; }
        [Required]
        public int GasId { get; set; }
        [Required]
        public int GearBoxId { get; set; }
        [Required]
        public int ModelId { get; set; }
        [Required]
        public IFormFile[] Photos{ get; set; }
    }
}
