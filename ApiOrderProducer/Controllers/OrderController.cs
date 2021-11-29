using ApiOrderProducer.Domain;
using ApiOrderProducer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ApiOrderProducer.Controllers
{
    [Route("api-order-producer/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult InsertOrder(Order order)
        {
            try
            {

                OrderPublish.pubOrderQueue(order);

                _logger.LogInformation($"Inserido na fila com sucesso o pedido {order.OrderId}");
                return Accepted("Inserido com sucesso");
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao tentar inserir um novo pedido na fila {e}");
                return new StatusCodeResult(500);
            }
        }
    }
}
