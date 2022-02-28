
using System;
using System.Collections.Generic;
using CartService.Models;

namespace CartService.Repositories
{
    public interface ICartRepo
    {
        IEnumerable<Cart> GetCart();
        //company GetCompany(Guid id);
        Cart GetCart(Guid id);
        void CreateCart(Cart cart);
    }
}