using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.Entities
{
    public class DonationPost : DeletableEntity
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public int FieldId { get; set; }

        public virtual User User { get; set; }
        public virtual Field Field { get; set; }
    }
}
