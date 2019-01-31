using System;
using System.ComponentModel.DataAnnotations;

namespace ProductsCategories.Models
{
    public class CatProd
    {
        [Key]
        public int CatProdId { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set;}

        public int ProductId { get; set; }
        public Product Product { get; set;}

    }
}