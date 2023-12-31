﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarAnnouncements.Models
{
    public class User
    {
        
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public List<Announcement> Announcements { get; set; }
   
    }
}
