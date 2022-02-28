
using System;

namespace OrderService.Dtos
{
    public record OrderDtos
    {
        public Guid OrderId {get; init;}
         public int[] ProductId {get; init;}    

        public double[] Price { get; init; }
        public double Total { get; init; }

    }
}