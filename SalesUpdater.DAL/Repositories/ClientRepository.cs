using AutoMapper;
using SalesUpdater.Entity;
using SalesUpdater.Interfaces.Core.DataTransferObject;
using SalesUpdater.Interfaces.DAL.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SalesUpdater.DAL.Repositories
{
    class ClientRepository : Repository<ClientDTO, Client>, IClientRepository
    {
        public ClientRepository(SalesContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public void AddClientToDatabase(ClientDTO clientDto)
        {
            Expression<Func<ClientDTO, bool>> predicate = x =>
                x.Surname == clientDto.Surname && x.Name == clientDto.Name;

            if (!Find(predicate).Any())
            {
                Add(clientDto);
            }
        }

        public int? GetId(string customerFirstName, string customerLastName)
        {
            Expression<Func<ClientDTO, bool>> predicate = x =>
                x.Name == customerFirstName && x.Surname == customerLastName;

            return Find(predicate).First().ID;
        }
    }
}
