using System;

namespace AlDarb.Entities
{
    public class CourseSession : DeletableEntity
    {
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; private set; }
        public virtual Course Course { get; set; }
    }
}
