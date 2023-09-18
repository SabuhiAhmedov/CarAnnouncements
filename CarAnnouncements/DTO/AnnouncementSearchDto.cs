using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAnnouncements.DTO
{
    public class AnnouncementSearchDto
    {
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinYear { get; set; }
        public int? MaxYear { get; set; }
        public int? MinDistance { get; set; }
        public int? MaxDistance { get; set; }
        public int? MinEngineVolume { get; set; }
        public int? MaxEngineVolume { get; set; }
        public int? BanId { get; set; }
        public int? ColorId { get; set; }
        public int? GasId { get; set; }
        public int? GearBoxId { get; set; }
        public int? ModelId { get; set; }
        public int? MarkId { get; set; }

    }
}
