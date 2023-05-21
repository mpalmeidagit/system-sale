using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using SystemSale.DAL.DBContext;
using SystemSale.DAL.Repository.Contract;

namespace SystemSale.DAL.Repository
{
    public class GenericRepository<TModelo> : IGenericRepository<TModelo> where TModelo : class
    {
        private readonly DbsaleContext _dbContext;
        public GenericRepository(DbsaleContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TModelo> Create(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TModelo> Get(Expression<Func<TModelo, bool>> filter)
        {
            try
            {
                TModelo modelo = await _dbContext.Set<TModelo>().FirstOrDefaultAsync(filter);
                return modelo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IQueryable<TModelo>> GetAll(Expression<Func<TModelo, bool>> filter = null)
        {
            try
            {
                IQueryable<TModelo> query = filter == null ? _dbContext.Set<TModelo>() : _dbContext.Set<TModelo>().Where(filter);
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
