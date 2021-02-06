using SalesUpdater.Interfaces.Core.DataTransferObject;

namespace SalesUpdater.Interfaces.DAL.Repositories
{
    public interface IProductRepository : IRepository<ProductDTO>
    {
        void AddProductToDatabase(ProductDTO productDto);

        int? GetId(string productName);
    }
}
