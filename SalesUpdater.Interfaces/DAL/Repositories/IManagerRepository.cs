using SalesUpdater.Interfaces.Core.DataTransferObject;

namespace SalesUpdater.Interfaces.DAL.Repositories
{
    public interface IManagerRepository: IRepository<ManagerDTO>
    {
        void AddManagerToDatabase(ManagerDTO managerDto);

        int? GetId(string managerSurname);
    }
}
