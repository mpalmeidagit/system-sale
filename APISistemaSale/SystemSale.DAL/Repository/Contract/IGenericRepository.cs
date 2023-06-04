using System.Linq.Expressions;

namespace SystemSale.DAL.Repository.Contract
{
    public interface IGenericRepository<TModelo> where TModelo : class
    {
        Task<TModelo> Get(Expression<Func<TModelo, bool>> filter);
        Task<TModelo> Create(TModelo model);
        Task<bool> Update(TModelo model);
        Task<bool> Delete(TModelo model);
        Task<IQueryable<TModelo>> GetAll(Expression<Func<TModelo, bool>>? filter = null);
    }
}
