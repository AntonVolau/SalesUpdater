using AutoMapper;
using SalesUpdater.Entity;
using SalesUpdater.Interfaces.Core.DataTransferObject;
using SalesUpdater.Interfaces.DAL.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SalesUpdater.DAL.Repositories
{
    public class ProductRepository : Repository<ProductDTO, Product>, IProductRepository
    {
        public ProductRepository(SalesContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public void AddProductToDatabase(ProductDTO productDto)
        {
            Expression<Func<ProductDTO, bool>> predicate = x => x.Name == productDto.Name;

            if (Find(predicate).Any()) return;

            Add(productDto);
        }

        public int? GetId(string productName)
        {
            Expression<Func<ProductDTO, bool>> predicate = x => x.Name == productName;

            return Find(predicate).First().ID;
        }
    }
}
