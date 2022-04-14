using System;
using System.Collections.Generic;

namespace workoholicshop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime OrderFinishDate { get; set; }
        public int TotalPrice { get; set; }
        public int PaymentState { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }

        public int CouponId { get; set; }
        public Coupon Coupon { get; set; }


        public List<Cart> Carts { get; set; }
    }
}
