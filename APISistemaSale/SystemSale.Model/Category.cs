using System;
using System.Collections.Generic;

namespace SystemSale.Model;

public partial class Category
{
    public int IdCategory { get; set; }

    public string? Name { get; set; }

    public bool? IsActivo { get; set; }

    public DateTime? DateRegistration { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
