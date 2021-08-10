using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; }
    }
}
