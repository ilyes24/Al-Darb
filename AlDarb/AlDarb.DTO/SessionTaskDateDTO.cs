using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.DTO
{
    public class SessionTaskDateDTO
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int SessionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
