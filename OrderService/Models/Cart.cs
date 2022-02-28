
using System;

namespace OrderService.Models
{
    public record Cart
    {
        public Guid CardId {get; init;}
        public int[] ProductId {get; init;}       

        public double[] Price { get; init; }
        public double Total { get; init; }
        public String Status { get; init; }
        public Guid OrderId {get; init;}
    }
}