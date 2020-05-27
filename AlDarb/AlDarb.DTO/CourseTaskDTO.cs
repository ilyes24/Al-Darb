using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.DTO
{
    public class CourseTaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Difficulty { get; set; }

        public int CourseId { get; set; }
    }
}
