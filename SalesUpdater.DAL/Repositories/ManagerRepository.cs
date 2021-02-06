using AutoMapper;
using SalesUpdater.Entity;
using SalesUpdater.Interfaces.Core.DataTransferObject;
using SalesUpdater.Interfaces.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesUpdater.DAL.Repositories
{
    public class ManagerRepository : Repository<ManagerDTO, Manager>, IManagerRepository
    {
        public ManagerRepository(SalesContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public void AddManagerToDatabase(ManagerDTO managerDto)
    {
        Expression<Func<ManagerDTO, bool>> predicate = x => x.Surname == managerDto.Surname;

        if (Find(predicate).Any()) return;

        Add(managerDto);
    }

    public int? GetId(string managerLastName)
    {
        Expression<Func<ManagerDTO, bool>> predicate = x => x.Surname == managerLastName;

        return Find(predicate).First().ID;
    }
}
}
