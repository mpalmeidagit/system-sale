using SystemSale.DTO;

namespace SystemSale.BLL.Services.Contract
{
    public interface ISaleService
    {
        Task<SaleDTO> Create(SaleDTO saleDTO);
        Task<List<SaleDTO>> Historic(string searchPer, string numberSale, string dateStart, string dateEnd);
        Task<List<ReportDTO>> Report(string dateStart, string dateEnd);     

    }
}
