using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarAnnouncements.DTO
{
    public class UserRegisterDto
    {
        [Required]
        public string Username { get; set; }      
        [DataType(DataType.Password)]
        [Required, MinLength(6,ErrorMessage =("Password must consist of minimum 6 characters"))]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
