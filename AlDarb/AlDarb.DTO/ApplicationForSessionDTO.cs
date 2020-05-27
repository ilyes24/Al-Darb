using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.DTO
{
    public class ApplicationForSessionDTO
    {
        public int Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public bool? Status { get; set; }
        public DateTime? AcceptedDate { get; set; }

        public int UserId { get; set; }
        public int CourseSessionId { get; set; }
    }
}
