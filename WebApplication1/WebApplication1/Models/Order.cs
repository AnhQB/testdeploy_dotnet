using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? MemberId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public bool? Discount { get; set; }

        public virtual Member? Member { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
