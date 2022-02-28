
using System;
using System.ComponentModel.DataAnnotations;

namespace OrderService.Dtos
{
    public record CreateOrderDtos
    {
        [Required]
         public int[] ProductId {get; init;}        

        [Required]
        public double[] Price { get; init; }
        [Required]
        public double Total { get; init; }
       
        
    }
}