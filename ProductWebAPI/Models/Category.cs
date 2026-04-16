
using System;
using ProductWebAPI.Models;
using System.Collections.Generic;



namespace ProductWebAPI.Models;



public partial class Category
{
    public int CategoryId { get; set; }



    public string CategoryName { get; set; } = null!;



    public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
}

