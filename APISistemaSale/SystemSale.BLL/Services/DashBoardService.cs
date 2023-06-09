using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using SystemSale.BLL.Services.Contract;
using SystemSale.DAL.Repository.Contract;
using SystemSale.DTO;
using SystemSale.Model;

namespace SystemSale.BLL.Services
{
    public class DashBoardService : IDashBoardService
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly ISaleRepository _saleRepository;


        public Task<DashBoardDTO> Summary()
        {
            throw new NotImplementedException();
        }
    }
}
