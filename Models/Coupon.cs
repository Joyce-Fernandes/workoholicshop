using System;

namespace workoholicshop.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Discount { get; set; }   

    }
}
