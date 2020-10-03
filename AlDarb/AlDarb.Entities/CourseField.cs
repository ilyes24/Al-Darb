using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.Entities
{
    public class CourseField : DeletableEntity
    {
        public int CourseId { get; set; }
        public int FieldId { get; set; }

        public virtual Field Field { get; set; }
        public virtual Course Course { get; set; }
    }
}
