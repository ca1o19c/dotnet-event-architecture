using System;

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
