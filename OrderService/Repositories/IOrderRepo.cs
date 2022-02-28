
using System;
using System.Collections.Generic;
using OrderService.Models;

namespace OrderService.Repositories
{
    public interface IOrderRepo
    {
        IEnumerable<Order> GetOrder();
        //company GetCompany(Guid id);
        Order GetOrder(Guid id);
        void CreateOrder(Order order);

    }
}