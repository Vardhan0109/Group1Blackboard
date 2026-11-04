
using System.Collections.Generic;

namespace Group1Blackboard.Models
{
    public class CourseCatalogViewModel
    {
        public List<Course> Courses { get; set; } = new List<Course>();

        public List<Major> Majors { get; set; } = new List<Major>();

        public int? SelectedMajorID { get; set; }

        public string SelectedSemester { get; set; } = "All";

        public string SelectedLocation { get; set; } = "All";
    }
}
