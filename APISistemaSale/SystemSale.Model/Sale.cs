namespace SystemSale.Model;

public partial class Sale
{
    public int IdSale { get; set; }

    public string? NumberDocument { get; set; }

    public string? TypePayment { get; set; }

    public decimal? Total { get; set; }

    public DateTime? DateRegistration { get; set; }

    public virtual ICollection<DetailsSale> DetailsSales { get; } = new List<DetailsSale>();
}
