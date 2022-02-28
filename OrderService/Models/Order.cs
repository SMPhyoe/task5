using System;

namespace OrderService.Models
{
    public record Order
    {
        public Guid OrderId {get; init;}
        public int[] ProductId {get; init;}       

        public double[] Price { get; init; }
        public double Total { get; init; }
        
        
    }
}