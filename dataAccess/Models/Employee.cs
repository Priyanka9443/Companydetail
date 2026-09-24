using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;    
using System.Text;

namespace dataAccess.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        [StringLength(50)]
        [Required]
        public string? name { get; set; }
        [StringLength(50),Required]
        public string? email { get; set; }
        [Required]
        [StringLength(20)]
        public string? password { get; set; }

    }
}
