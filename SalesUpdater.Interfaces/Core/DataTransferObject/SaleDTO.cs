using System;

namespace SalesUpdater.Interfaces.Core.DataTransferObject
{
    public class SaleDTO : DataTransferObject
    {
        public DateTime Date { get; set; }

        public ClientDTO Client { get; set; }

        public ProductDTO Product { get; set; }

        public decimal Sum { get; set; }

        public ManagerDTO Manager { get; set; }

        public SaleDTO(DateTime date, ClientDTO client, ProductDTO product, decimal sum, ManagerDTO manager)
        {
            Date = date;
            Client = client;
            Product = product;
            Sum = sum;
            Manager = manager;
        }
    }
}
