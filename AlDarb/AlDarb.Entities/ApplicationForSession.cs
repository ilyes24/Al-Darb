using System;

namespace AlDarb.Entities
{
    public class ApplicationForSession : DeletableEntity
    {
        public DateTime ApplicationDate { get; set; }
        public bool? Status { get; set; }
        public DateTime? AcceptedDate { get; set; }

        public int UserId { get; set; }
        public int CourseSessionId { get; set; }

        public virtual User User { get; set; }
        public virtual CourseSession CourseSession { get; set; }
    }
}
