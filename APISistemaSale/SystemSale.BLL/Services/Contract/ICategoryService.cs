using SystemSale.DTO;


namespace SystemSale.BLL.Services.Contract
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> List();
    }
}
