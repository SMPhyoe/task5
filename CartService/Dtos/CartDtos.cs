
using System;

namespace CartService.Dtos
{
    public record CartDtos
    {
        public Guid CardId {get; init;}
         public int[] ProductId {get; init;}    

        public double[] Price { get; init; }
        public double Total { get; init; }
        public String Status { get; init; }
         public Guid OrderId {get; init;}
    }
}