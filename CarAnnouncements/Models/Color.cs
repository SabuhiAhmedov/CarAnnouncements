using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAnnouncements.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<Announcement> Announcements { get; set; }
    }
}
