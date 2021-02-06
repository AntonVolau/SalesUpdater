using AutoMapper;
using SalesUpdater.Entity;
using SalesUpdater.Interfaces.Core.DataTransferObject;

namespace SalesUpdater.DAL
{
    internal static class AutoMapper
    {
        internal static MapperConfiguration CreateConfiguration()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Client, ClientDTO>();
                config.CreateMap<ClientDTO, Client>();

                config.CreateMap<Product, ProductDTO>();
                config.CreateMap<ProductDTO, Product>();

                config.CreateMap<Manager, ManagerDTO>();
                config.CreateMap<ManagerDTO, Manager>();

                config.CreateMap<Sale, SaleDTO>();
                config.CreateMap<SaleDTO, Sale>()
                    .ForMember(x => x.Client, opt => opt.Ignore())
                    .ForMember(x => x.Manager, opt => opt.Ignore())
                    .ForMember(x => x.Product, opt => opt.Ignore());
            });
        }
    }
}
