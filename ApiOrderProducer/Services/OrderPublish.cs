using ApiOrderProducer.Domain;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace ApiOrderProducer.Services
{
    public static class OrderPublish
    {
        public static void pubOrderQueue(Order order)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "OrderQueue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                string message = JsonSerializer.Serialize(order);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "OrderQueue",
                                     basicProperties: null,
                                     body: body);
            }
        }

    }
}
