using OrderService.Dtos;
using OrderService.Models;

namespace OrderService
{
    public static class Extensions
    {
        public static OrderDtos AsDto(this Order Order)
        {
            return new OrderDtos{
                OrderId = Order.OrderId,
                ProductId = Order.ProductId,
                Price = Order.Price,
                Total = Order.Total
            };
        }
    }
}