using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using SystemSale.BLL.Services.Contract;
using SystemSale.DAL.Repository.Contract;
using SystemSale.DTO;
using SystemSale.Model;

namespace SystemSale.BLL.Services
{
    public class SaleService : ISaleService
    {
        private readonly IGenericRepository<DetailsSale> _detailsRepository;
        private readonly IMapper _mapper;
        private readonly ISaleRepository _saleRepository;

        public SaleService(IGenericRepository<DetailsSale> repository, IMapper mapper, ISaleRepository saleRepository)
        {
            _detailsRepository = repository;
            _mapper = mapper;
            _saleRepository = saleRepository;
        }

        public async Task<SaleDTO> Create(SaleDTO saleDTO)
        {
            try
            {
                var saleGenerated = await _saleRepository.Create(_mapper.Map<Sale>(saleDTO));
                if (saleGenerated.IdSale == 0)
                    throw new TaskCanceledException("Não foi possível criar a venda");

                return _mapper.Map<SaleDTO>(saleGenerated);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<SaleDTO>> Historic(string searchPer, string numberSale, string dateStart, string dateEnd)
        {
            IQueryable<Sale> query = await _saleRepository.GetAll();
            var listResult = new List<Sale>();
            try
            {
                if (searchPer == "date")
                {
                    DateTime date_stard = DateTime.ParseExact(dateStart, "dd/MM/yyyy", new CultureInfo("pt-BR"));
                    DateTime date_end = DateTime.ParseExact(dateEnd, "dd/MM/yyyy", new CultureInfo("pt-BR"));

                    listResult = await query.Where(v => v.DateRegistration.Value.Date >= date_stard.Date && v.DateRegistration.Value.Date <= date_end).Include(dv => dv.DetailsSales).ThenInclude(p => p.IdProductNavigation).ToListAsync();

                }
                else
                {
                    listResult = await query.Where(v => v.NumberDocument == numberSale).Include(dv => dv.DetailsSales).ThenInclude(p => p.IdProductNavigation).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return _mapper.Map<List<SaleDTO>>(listResult);
        }

        public async Task<List<ReportDTO>> Report(string dateStart, string dateEnd)
        {
            IQueryable<DetailsSale> query = await _detailsRepository.GetAll();
            var listResult = new List<DetailsSale>();
            try
            {
                DateTime date_stard = DateTime.ParseExact(dateStart, "dd/MM/yyyy", new CultureInfo("pt-BR"));
                DateTime date_end = DateTime.ParseExact(dateEnd, "dd/MM/yyyy", new CultureInfo("pt-BR"));

                listResult = await query
                    .Include(p => p.IdProductNavigation)
                    .Include(v => v.IdSaleNavigation)
                    .Where(dv => dv.IdSaleNavigation.DateRegistration.Value.Date >= date_stard.Date && dv.IdSaleNavigation.DateRegistration.Value.Date <= date_end.Date).ToListAsync();
                    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return _mapper.Map<List<ReportDTO>>(listResult);
        }
    }
}
