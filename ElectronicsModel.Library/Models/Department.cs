using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Models
{
    public class Department
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; }


        public virtual Store Store { get; set; }
        public virtual ICollection<Employee> Employess { get; set; }

        public Department()
        {
            Store = new Store();
        }
    }
}
