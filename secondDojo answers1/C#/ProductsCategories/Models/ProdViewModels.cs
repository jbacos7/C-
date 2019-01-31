using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;


namespace ProductsCategories.Models
{
  public class ProdViewModels
  {
    [Required]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters.")]
    public string Name { get; set; }

    [Required]
    [MinLength(8, ErrorMessage = "Description must be at least 8 characters.")]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

  }
}
