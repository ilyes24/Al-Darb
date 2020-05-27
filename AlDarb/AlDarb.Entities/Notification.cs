using System;

namespace AlDarb.Entities
{
    public class Notification : DeletableEntity
    {
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string RedirectUrl { get; set; }

        public virtual User User { get; set; }
    }
}
