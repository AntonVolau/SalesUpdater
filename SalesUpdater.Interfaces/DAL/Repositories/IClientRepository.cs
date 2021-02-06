using SalesUpdater.Interfaces.Core.DataTransferObject;

namespace SalesUpdater.Interfaces.DAL.Repositories
{
    public interface IClientRepository : IRepository<ClientDTO>
    {
        void AddClientToDatabase(ClientDTO clientDto);

        int? GetId(string name, string surname);
    }
}
