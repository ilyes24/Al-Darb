using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.DTO
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string RedirectUrl { get; set; }

        public int UserId { get; set; }
    }
}
