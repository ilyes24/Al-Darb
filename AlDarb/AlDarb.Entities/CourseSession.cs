using System;
using System.Collections.Generic;

namespace AlDarb.Entities
{
    public class CourseSession : DeletableEntity
    {
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; private set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<ApplicationForSession> ApplicationForSessions { get; set; }
    }
}
