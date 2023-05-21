using System;
using System.Collections.Generic;

namespace SystemSale.Model;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? Name { get; set; }

    public int? IdCategory { get; set; }

    public int? Stock { get; set; }

    public decimal? Price { get; set; }

    public bool? IsActivo { get; set; }

    public DateTime? DateRegistration { get; set; }

    public virtual ICollection<DetailsSale> DetailsSales { get; } = new List<DetailsSale>();

    public virtual Category? IdCategoryNavigation { get; set; }
}
