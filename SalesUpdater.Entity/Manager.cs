using System.Collections.Generic;

namespace SalesUpdater.Entity
{
    public class Manager
    {
        public Manager()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int ID { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
