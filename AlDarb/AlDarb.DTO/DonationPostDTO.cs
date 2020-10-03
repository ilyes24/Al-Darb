using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.DTO
{
    public class DonationPostDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public int FieldId { get; set; }
    }
}
