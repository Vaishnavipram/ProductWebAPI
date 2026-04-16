
using System;
using ProductWebAPI.Models;
using System.Collections.Generic;



namespace ProductWebAPI.Models;



public partial class Product
{
    public int ProductId { get; set; }



    public string ProductName { get; set; } = null!;





    public short ModelYear { get; set; }



    public decimal ListPrice { get; set; }
    public int BrandId { get; set; }



    public virtual Brand Brand { get; set; } = null!;



    public int CategoryId { get; set; }



    public virtual Category Category { get; set; } = null!;




}

