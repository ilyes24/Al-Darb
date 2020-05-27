using System;

namespace AlDarb.Entities
{
    public class ProgressTask : DeletableEntity
    {
        public string progress { get; set; }
        public DateTime ProgressDate { get; set; }
        public int? rating { get; set; }

        public virtual CourseTask CourseTask { get; set; }
        public virtual User User { get; set; }
    }
}
