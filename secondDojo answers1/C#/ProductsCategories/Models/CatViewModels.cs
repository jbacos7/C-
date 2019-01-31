using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;


namespace ProductsCategories.Models
{
    public class CatViewModels
    {

    [Required]
    [MinLength(2, ErrorMessage = "Name of category must be at least 2 characters.")]
    public string CatName { get; set; }
    }
}