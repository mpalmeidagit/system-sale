namespace SystemSale.DTO
{
    public class DashBoardDTO
    {
        public int TotalSale { get; set; }
        public string? TotalIncome { get; set; }
        public List<SaleWeekDTO>? SaleLastWeek { get; set; }

    }
}
