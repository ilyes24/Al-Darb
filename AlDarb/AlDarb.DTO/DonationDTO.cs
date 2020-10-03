using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.DTO
{
    public class DonationDTO
    {
        public int Id { get; set; }
        public double DonationAmount { get; set; }
        public int UserId { get; set; }
        public int DonationPostId { get; set; }
        public string PaypalEmail { get; set; }
    }
}
