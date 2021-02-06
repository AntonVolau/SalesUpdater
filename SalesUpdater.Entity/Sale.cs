using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesUpdater.Entity
{
    public class Sale
    {
        public int ID { get; set; }
        public int ManagerId { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Sum { get; set; }

        public virtual Manager Manager { get; set; }
        public virtual Product Product { get; set; }
        public virtual Client Client { get; set; }
    }
}
