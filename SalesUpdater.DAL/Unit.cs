using SalesUpdater.Entity;
using SalesUpdater.Interfaces.Core.DataTransferObject;
using SalesUpdater.Interfaces.DAL;
using SalesUpdater.Interfaces.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using AutoMapper;
using SalesUpdater.DAL.Repositories;

namespace SalesUpdater.DAL
{
    public class Unit : IUnit
    {
        private SalesContext Context { get; }
        private ReaderWriterLockSlim Locker { get; }

        private IClientRepository Clients { get; }
        private IManagerRepository Managers { get; }
        private IProductRepository Products { get; }
        private ISaleRepository Sales { get; }

        public Unit(SalesContext context, ReaderWriterLockSlim locker)
        {
            Context = context;
            Locker = locker;

            var mapper = AutoMapper.CreateConfiguration().CreateMapper();
            Clients = new ClientRepository(Context, mapper);
            Managers = new ManagerRepository(Context, mapper);
            Products = new ProductRepository(Context, mapper);
            Sales = new SaleRepository(Context, mapper);
        }

        public void Add(params SaleDTO[] models)
        {
            Locker.EnterWriteLock();
            try
            {
                foreach (var sale in models)
                {
                    Clients.AddClientToDatabase(sale.Client);
                    Clients.Save();
                    sale.Client.ID = Clients.GetId(sale.Client.Name, sale.Client.Surname);

                    Managers.AddManagerToDatabase(sale.Manager);
                    Managers.Save();
                    sale.Manager.ID = Managers.GetId(sale.Manager.Surname);

                    Products.AddProductToDatabase(sale.Product);
                    Products.Save();
                    sale.Product.ID = Products.GetId(sale.Product.Name);

                    Sales.Add(sale);
                    Sales.Save();
                }
            }
            finally
            {
                Locker.ExitWriteLock();
            }
        }

        public IEnumerable<SaleDTO> GetAll()
        {
            return Sales.GetAll();
        }
    }
}
