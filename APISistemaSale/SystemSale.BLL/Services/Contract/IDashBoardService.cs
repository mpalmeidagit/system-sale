using SystemSale.DTO;

namespace SystemSale.BLL.Services.Contract
{
    public interface IDashBoardService
    {
        Task<DashBoardDTO> Summary();
    }
}
