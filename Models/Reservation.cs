
using System;

namespace Group1Blackboard.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }

        public int CourseID { get; set; }

        public Course? Course { get; set; }

        public int AppUserID { get; set; }

        public AppUser? AppUser { get; set; }

        public DateTime ReservationDate { get; set; }
            = DateTime.Now;
    }
}
