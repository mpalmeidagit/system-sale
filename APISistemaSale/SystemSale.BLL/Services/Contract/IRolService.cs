using SystemSale.DTO;

namespace SystemSale.BLL.Services.Contract
{
    public interface IRolService
    {
        Task<List<RolDTO>> List();
    }
}
