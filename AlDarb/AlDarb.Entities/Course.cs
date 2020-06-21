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

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<CourseSession> CourseSessions { get; set; }
        public virtual ICollection<CourseTask> CourseTasks { get; set; }
    }
}
