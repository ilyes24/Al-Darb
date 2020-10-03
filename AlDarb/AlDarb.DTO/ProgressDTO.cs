using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.DTO
{
    class ProgressDTO
    {
        public int Id { get; set; }
        public CourseDTO Course { get; set; }
        public CourseSessionDTO Session { get; set; }
        public ICollection<SessionTaskDateDTO> Dates { get; set; }
    }
}
