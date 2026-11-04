
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Group1Blackboard.Models
{
    public class AppUser
    {
        
public static List<string> Roles { get; } = new List<string>
{
    "Student",
    "Instructor",
    "Staff",
    "Admin"
};

        public int AppUserID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string SSN { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;

        public ICollection<Course> Courses { get; set; }
            = new List<Course>();
    }
}
