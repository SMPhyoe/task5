using System;
using System.Collections.Generic;
using System.Linq;
using CartService.Models;

namespace CartService.Repositories
{
    public class CharRepo : ICartRepo
    {
        private readonly List<Cart> Cart = new()
        {
            new Cart { CardId = Guid.NewGuid(), ProductId = new int[] { 1, 3, 5, 7, 9 },  Price = new double[] { 5, 33, 15, 7, 19 } ,  Total = 79 , Status = "SUCCESS",OrderId = Guid.NewGuid()},
            new Cart { CardId = Guid.NewGuid(), ProductId = new int[] { 7, 9 }, Price = new double[] { 5, 33 } ,  Total = 38 , Status = "SUCCESS",OrderId = Guid.NewGuid()},
            new Cart { CardId = Guid.NewGuid(), ProductId = new int[] { 1, 3, 5, 7, 9 },  Price = new double[] { 5, 33, 15, 7, 19 } ,  Total = 79 , Status = "FAILED",OrderId = Guid.NewGuid()},
            new Cart { CardId = Guid.NewGuid(), ProductId = new int[] { 1, 3, 5, 7, 9 },  Price = new double[] { 5, 33, 15, 7, 19 } ,  Total = 79 , Status = "INITIATED",OrderId = Guid.NewGuid()},
            new Cart { CardId = Guid.NewGuid(), ProductId = new int[] { 1, 3, 5, 7, 9 },  Price = new double[] { 5, 33, 15, 7, 19 } ,  Total = 79 , Status = "SUCCESS",OrderId = Guid.NewGuid()}
        };
        public void CreateCart(Cart cart)
        {
            this.Cart.Add(cart);
        }

        public Cart GetCart(Guid id)
        {
            return Cart.Where(Cart => Cart.CardId == id).SingleOrDefault();
        }

        public IEnumerable<Cart> GetCart()
        {
            return Cart;
        }
    }
}