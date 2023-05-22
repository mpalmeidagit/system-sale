namespace SystemSale.DTO
{
    public class SaleDTO
    {
        public int IdSale { get; set; }

        public string? NumberDocument { get; set; }

        public string? TypePayment { get; set; }

        public string? Total { get; set; }

        public string? DateRegistration { get; set; }

        public virtual ICollection<DetailsSaleDTO> DetailsSalesDTO { get; set; }
    }
}
