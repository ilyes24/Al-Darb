using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.Entities
{
    public class CourseRating : DeletableEntity
    {
        public int Rating { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
    }
}
