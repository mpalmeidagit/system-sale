using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SystemSale.BLL.Services.Contract;
using SystemSale.DAL.Repository.Contract;
using SystemSale.DTO;
using SystemSale.Model;

namespace SystemSale.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Create(ProductDTO productDTO)
        {
            try
            {
                var productCreate = await _repository.Create(_mapper.Map<Product>(productDTO));
                if (productCreate.IdProduct == 0)
                    throw new TaskCanceledException("Não foi possível cadastrar produto");
             

                return _mapper.Map<ProductDTO>(productCreate);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
             
                var productDelete = await _repository.Get(p => p.IdProduct == id);

                if (productDelete == null)
                    throw new TaskCanceledException("Produto não existe");

                bool response = await _repository.Delete(productDelete);

                if (!response)
                    throw new TaskCanceledException("Não foi possível deletar o produto");

                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProductDTO>> List()
        {
            try
            {
                var query = await _repository.GetAll();
                var listProduto = query.Include(c => c.IdCategoryNavigation).ToList();

                return _mapper.Map<List<ProductDTO>>(listProduto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(ProductDTO productDTO)
        {
            try
            {
                var productUpdate = _mapper.Map<Product>(productDTO);
                var productFound = await _repository.Get(p => p.IdProduct == productUpdate.IdProduct);

                if (productFound == null)
                    throw new TaskCanceledException("Produto não existe");

                productFound.Name = productUpdate.Name;
                productFound.IdCategory = productUpdate.IdCategory;
                productFound.Stock = productUpdate.Stock;
                productFound.Price = productUpdate.Price;
                productFound.IsActivo = productUpdate.IsActivo;

                bool response = await _repository.Update(productUpdate);

                if(!response)
                    throw new TaskCanceledException("Não foi possível editar o produto");


                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
