using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Models
{
    
    public class OrderFrom
    {
        public int OrderId { get; set; }
        public int? MemberId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public bool? Discount { get; set; }

    }

}
