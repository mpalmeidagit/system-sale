namespace SystemSale.DTO
{
    public class DetailsSaleDTO
    {
        public int IdDetailsSale { get; set; }

        public int? IdSale { get; set; }

        public int? IdProduct { get; set; }

        public string? ProductDesciption { get; set; }

        public int? Amount { get; set; }

        public string? Price { get; set; }

        public string? Total { get; set; }
    }
}
