using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.Entities
{
    public class SessionTaskDate : DeletableEntity
    {
        public int TaskId { get; set; }
        public int SessionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual CourseSession CourseSession { get; set; }
        public virtual CourseTask CourseTask { get; set; }
    }
}
