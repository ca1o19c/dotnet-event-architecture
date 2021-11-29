using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOrderProducer.Domain
{
    public class Order
    {
        public Order()
        {
            OrderId = Guid.NewGuid();
        }

        public Guid OrderId { get; set; }

        public string ItemName { get; set; }

        public string Price { get; set; }

    }
}
