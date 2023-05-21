using SystemSale.Model;

namespace SystemSale.DAL.Repository.Contract
{
    public interface ISaleRepository: IGenericRepository<Sale>
    {
        Task<Sale> Register(Sale modelo);
    }
}
