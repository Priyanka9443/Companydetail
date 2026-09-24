using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace dataAccess.Models
{
 public class Login
    {
        [Required]
        public string email { get; set; }
        
        [Required]
        public string password { get; set; }
    }
}
