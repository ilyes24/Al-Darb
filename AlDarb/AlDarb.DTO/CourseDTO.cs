using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
