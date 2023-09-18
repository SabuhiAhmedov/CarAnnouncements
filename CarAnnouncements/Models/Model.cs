using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAnnouncements.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Mark Mark { get; set; }
        public int MarkId { get; set; }
       public List<Announcement> Announcements { get; set; }
    }
}
