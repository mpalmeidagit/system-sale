using SystemSale.DTO;

namespace SystemSale.BLL.Services.Contract
{
    public interface IProductService
    {
        Task<List<ProductDTO>> List();      
        Task<ProductDTO> Create(ProductDTO productDTO);
        Task<bool> Update(ProductDTO productDTO);
        Task<bool> Delete(int id);
    }
}
