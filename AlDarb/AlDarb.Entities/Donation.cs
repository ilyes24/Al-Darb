using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.Entities
{
    public class Donation : DeletableEntity
    {
        public double DonationAmount { get; set; }
        public int UserId { get; set; }
        public int DonationPostId { get; set; }
        public string PaypalEmail { get; set; }

        public virtual DonationPost DonationPost { get; set; }
        public virtual User User { get; set; }
    }
}
