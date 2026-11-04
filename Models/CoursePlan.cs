
using System.Collections.Generic;
using System.Linq;

namespace Group1Blackboard.Models
{
    public class CoursePlan
    {
        public List<int> CourseIDs { get; set; } = new List<int>();

        public int Count => CourseIDs.Count;

        public void Add(int courseID)
        {
            if (!CourseIDs.Contains(courseID))
            {
                CourseIDs.Add(courseID);
            }
        }

        public void Remove(int courseID)
        {
            CourseIDs.Remove(courseID);
        }

        public void Clear()
        {
            CourseIDs.Clear();
        }
    }
}
