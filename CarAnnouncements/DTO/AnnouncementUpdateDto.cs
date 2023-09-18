using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarAnnouncements.DTO
{
    public class AnnouncementUpdateDto
    {
        public int? Price { get; set; }
        public int? Year { get; set; }
        public int? Distance { get; set; }
        public int? EngineVolume { get; set; }
        public int? BanId { get; set; }
        public int? ColorId { get; set; }
        public int? GasId { get; set; }  
        public int? GearBoxId { get; set; }      
        public int? ModelId { get; set; }    
        
        public IFormFile[] Photos { get; set; }
    }
}
