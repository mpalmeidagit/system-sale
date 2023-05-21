using SystemSale.DAL.DBContext;
using SystemSale.DAL.Repository.Contract;
using SystemSale.Model;

namespace SystemSale.DAL.Repository
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly DbsaleContext _dbContext;
        public SaleRepository(DbsaleContext dbContext): base(dbContext)
        {
                _dbContext = dbContext;
        }
        public async Task<Sale> Register(Sale modelo)
        {
            Sale salaGenerated = new Sale();

            using(var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetailsSale item in modelo.DetailsSales)
                    {
                        Product product = _dbContext.Products.Where(p => p.IdProduct == item.IdProduct).First();
                        if (product != null)
                        {
                            product.Stock = product.Stock - item.Amount;
                            _dbContext.Products.Update(product);
                        }
                        await _dbContext.SaveChangesAsync();

                        NumberDocument numberDocument = _dbContext.NumberDocuments.First();
                        if (numberDocument != null)
                        {
                            numberDocument.LastNumber = numberDocument.LastNumber + 1;
                            numberDocument.DateRegistration = DateTime.Now;

                            _dbContext.NumberDocuments.Update(numberDocument);
                            await _dbContext.SaveChangesAsync();
                        }

                        int quantityDigits = 4;
                        string zero = string.Concat(Enumerable.Repeat("0", quantityDigits));
                        string numberSale = zero + numberDocument.LastNumber.ToString();

                        numberSale = numberSale.Substring(numberSale.Length - quantityDigits, quantityDigits);

                        modelo.NumberDocument = numberSale;
                        await _dbContext.AddAsync(modelo);
                        await _dbContext.SaveChangesAsync();

                        salaGenerated = modelo;

                        transaction.Commit();

                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }

                return salaGenerated;
            }
        }
    }
}
