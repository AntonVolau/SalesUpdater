using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesUpdater.Interfaces.Core.DataTransferObject
{
    public class ManagerDTO : DataTransferObject
    {
        public string Surname { get; set; }

        public ManagerDTO(string surname)
        {
            Surname = surname;
        }
    }
}
