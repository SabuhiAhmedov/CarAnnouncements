using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAnnouncements.Models
{
    public class Images
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Announcement Announcement { get; set; }
        public int AnnouncementId { get; set; }
    }
}
