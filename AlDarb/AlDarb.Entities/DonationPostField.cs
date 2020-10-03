using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.Entities
{
    public class DonationPostField : DeletableEntity
    {
        public int DonationPostId { get; set; }
        public int FieldId { get; set; }

        public virtual Field Field { get; set; }
        public virtual DonationPost DonationPost { get; set; }
    }
}
