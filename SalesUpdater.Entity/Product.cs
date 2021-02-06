using System.Collections.Generic;

namespace SalesUpdater.Entity
{
    public class Product
    {
        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
