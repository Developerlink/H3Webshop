using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Dtos
{
    public class StoreDto
    {
        public int Id { get; set; }
        public int PostalCodeId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
    }
}
