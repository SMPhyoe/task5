using CartService.Dtos;
using CartService.Models;

namespace CartService
{
    public static class Extensions
    {
        public static CartDtos AsDto(this Cart Cart)
        {
            return new CartDtos{
                CardId = Cart.CardId,
                ProductId = Cart.ProductId,
                Price = Cart.Price,
                Total = Cart.Total,
                Status = Cart.Status,
                OrderId = Cart.OrderId
            };
        }
    }
}