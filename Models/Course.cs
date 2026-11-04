
using System.ComponentModel.DataAnnotations;

namespace Group1Blackboard.Models
{
    public class Course
    {
        
public static List<string> Semesters { get; } = new List<string>
{
    "Spring",
    "Fall",
    "Summer"
};

public static List<string> Locations { get; } = new List<string>
{
    "In-person",
    "Online",
    "Hybrid"
};

        public int CourseID { get; set; }

        [Required]
        public string CourseNumber { get; set; } = string.Empty;

        [Required]
        public string CourseName { get; set; } = string.Empty;

        public int Credit { get; set; }

        public string OfferedSemester { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public string Times { get; set; } = string.Empty;

        public string ShortDescription { get; set; } = string.Empty;

        public int MajorID { get; set; }

        public Major? Major { get; set; }

        public int? InstructorID { get; set; }

        public AppUser? Instructor { get; set; }
    }
}
