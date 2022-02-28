using System;
using System.Collections.Generic;
using System.Linq;
using CartService.Dtos;
using CartService.Models;
using CartService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CartService.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CartController :ControllerBase
    {
        private readonly ICartRepo repository;
        
        public CartController(ICartRepo repository)
        {
            this.repository = repository;
        }
        //GET /Order
        [HttpGet]
        public IEnumerable<CartDtos> GetCart ()
        {
            var Cart = repository.GetCart().Select(Cart => Cart.AsDto());            
            return Cart;
        }   

        // GET /Cart/{id}
        [HttpGet("{id}")]
        public ActionResult<CartDtos> GetCart(Guid id)
        {
            var Cart = repository.GetCart(id);

            if (Cart is null)
            {
                return NotFound();
            }

            return Cart.AsDto();
        }     

        // POST /Order
        [HttpPost]
        public ActionResult<CartDtos> CreateOrder(CreateCartDtos CartDtos)
        {
            Cart cart = new()
            {
                CardId = Guid.NewGuid(),
                ProductId = CartDtos.ProductId,
                Price = CartDtos.Price,
                Total = CartDtos.Total,
                Status = CartDtos.Status,
                OrderId = Guid.NewGuid()
            };

            repository.CreateCart(cart);
            Rabbit.SendMessage(cart);

            return CreatedAtAction(nameof(GetCart),new{CartId = cart.CardId},cart.AsDto());

        }

     

    }
}