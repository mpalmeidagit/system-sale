using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemSale.BLL.Services.Contract;
using SystemSale.DAL.Repository.Contract;
using SystemSale.DTO;
using SystemSale.Model;

namespace SystemSale.BLL.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly IGenericRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> List()
        {
            try
            {
                var listCategory = await _repository.GetAll();
                return _mapper.Map<List<CategoryDTO>>(listCategory.ToList());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
