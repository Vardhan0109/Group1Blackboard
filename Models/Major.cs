
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Group1Blackboard.Models
{
    public class Major
    {
        public int MajorID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string College { get; set; } = string.Empty;

        public ICollection<Course> Courses { get; set; }
            = new List<Course>();
    }
}
