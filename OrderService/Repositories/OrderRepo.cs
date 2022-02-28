using System;
using System.Collections.Generic;
using System.Linq;
using OrderService.Models;

namespace OrderService.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly List<Order> Order = new()
        {
            new Order { OrderId = Guid.NewGuid(), ProductId = new int[] { 1, 3, 5, 7, 9 },  Price = new double[] { 5, 33, 15, 7, 19 } ,  Total = 79 },
            new Order { OrderId = Guid.NewGuid(), ProductId = new int[] { 7, 9 }, Price = new double[] { 5, 33 } ,  Total = 38 },
            new Order { OrderId = Guid.NewGuid(), ProductId = new int[] { 1, 3, 5, 7, 9 },  Price = new double[] { 5, 33, 15, 7, 19 } },
            new Order { OrderId = Guid.NewGuid(), ProductId = new int[] { 1, 3, 5, 7, 9 },  Price = new double[] { 5, 33, 15, 7, 19 } },
            new Order { OrderId = Guid.NewGuid(), ProductId = new int[] { 1, 3, 5, 7, 9 },  Price = new double[] { 5, 33, 15, 7, 19 } }
        };
        public void CreateOrder(Order order)
        {
            this.Order.Add(order);
        }


        public Order GetOrder(Guid id)
        {
            return Order.Where(Order => Order.OrderId == id).SingleOrDefault();
        }

        public IEnumerable<Order> GetOrder()
        {
            return Order;
        }

    }
}