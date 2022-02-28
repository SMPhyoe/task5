
using System;
using System.ComponentModel.DataAnnotations;

namespace CartService.Dtos
{
    public record CreateCartDtos
    {
        [Required]
         public int[] ProductId {get; init;}        

        [Required]
        public double[] Price { get; init; }
        [Required]
        public double Total { get; init; }
        [Required]
        public String Status { get; init; }
        
    }
}