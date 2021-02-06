using AutoMapper;
using SalesUpdater.Entity;
using SalesUpdater.Interfaces.Core.DataTransferObject;
using SalesUpdater.Interfaces.DAL.Repositories;

namespace SalesUpdater.DAL.Repositories
{
    class SaleRepository : Repository<SaleDTO, Sale>, ISaleRepository
    {
        public SaleRepository(SalesContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
