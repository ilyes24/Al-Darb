using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.DTO
{
    public class ProgressTaskDTO
    {
        public int Id { get; set; }
        public string progress { get; set; }
        public string fileUrl { get; set; }
        public DateTime ProgressDate { get; set; }
        public int? rating { get; set; }

        public int CourseTaskId { get; set; }
        public int UserId { get; set; }
    }
}
