using AutoMapper;
using SystemSale.BLL.Services.Contract;
using SystemSale.DAL.Repository.Contract;
using SystemSale.DTO;
using SystemSale.Model;

namespace SystemSale.BLL.Services
{
    public class RolService: IRolService
    {
        private readonly IGenericRepository<Rol> _repository;
        private readonly IMapper _mapper;

        public RolService(IGenericRepository<Rol> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<RolDTO>> List()
        {
            try
            {
                var listRoles = await _repository.GetAll();
                return _mapper.Map<List<RolDTO>>(listRoles.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
