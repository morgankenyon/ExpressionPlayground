using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionPlayground
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Timestamp { get; set; }
        public int CustomerId { get; set; }
        public decimal Cost { get; set; }
    }
}
