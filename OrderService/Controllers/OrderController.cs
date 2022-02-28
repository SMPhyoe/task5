using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OrderService.Dtos;
using OrderService.Models;
using OrderService.Repositories;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrderController :ControllerBase
    {

        private readonly IOrderRepo repository;
        
        public OrderController(IOrderRepo repository)
        {
            this.repository = repository;
        }
        //GET /Order
        [HttpGet]
        public IEnumerable<OrderDtos> GetOrder ()
        {
            var rng = new Random();
            //Rabbit.getMessage();
            String message = Rabbit.getMessage();
            Cart cart = Newtonsoft.Json.JsonConvert.DeserializeObject<Cart>(message);


            Order order = new()
            {
                OrderId = cart.OrderId,
                ProductId = cart.ProductId,
                Price = cart.Price,
                Total = cart.Total

            };

            repository.CreateOrder(order);          

            var Order = repository.GetOrder().Select(Order => Order.AsDto());            
            return Order;
        }         

     

    }
}