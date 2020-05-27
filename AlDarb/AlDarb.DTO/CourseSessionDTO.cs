using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.DTO
{
    public class CourseSessionDTO
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; private set; }
        public int CourseId { get; set; }
    }
}
