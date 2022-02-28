using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using RabbitMQ.Client.Events;
using System.Text;
using System.Diagnostics;
using OrderService.Models;
using OrderService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace OrderService
{
   public static class Rabbit
    {
        
        public static String getMessage()
    {
       
            String messages = "";            
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    messages = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", messages);
                    Trace.WriteLine(" [x] Received {0}", messages);
                   
                    //IOrderRepo repo;
                    //repo.CreateOrder(order);
                };
                channel.BasicConsume(queue: "orders",  autoAck: true, consumer: consumer);

            //    Console.WriteLine(" Press [enter] to exit.");
            //    Console.ReadLine();
            }

            return messages;
    }

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
                             routingKey: "order-processe",
                             basicProperties: null,
                             body: bytes);
        }

        
    }
    }
}