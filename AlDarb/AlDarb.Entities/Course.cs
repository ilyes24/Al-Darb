using System.Collections;
using System.Collections.Generic;

namespace AlDarb.Entities
{
    public class Course : DeletableEntity
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }

        public int AvgRating { get; set; }
        public int SumRating { get; set; }

        public int FieldId { get; set; }
        public int UserId { get; set; }

        public virtual Field Field { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<CourseSession> CourseSessions { get; set; }
        public virtual ICollection<CourseTask> CourseTasks { get; set; }
        public virtual ICollection<CourseRating> CourseRatings { get; set; }
    }
}
