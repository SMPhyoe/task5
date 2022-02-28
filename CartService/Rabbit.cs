using CartService.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace CartService
{
    public static class Rabbit
    {
        public static void SendMessage(Cart cart)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using(var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            //var message = $"Hello World";
            var message = JsonConvert.SerializeObject(cart);
            var bytes = System.Text.Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                             routingKey: "orders",
                             basicProperties: null,
                             body: bytes);
        }

        //Console.WriteLine(" Press [enter] to exit.");
        //Console.ReadLine();
    }
    }
}