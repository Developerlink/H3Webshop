using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsORM.Library.Interfaces
{
    public interface IProductTypeRepository
    {
        ICollection<ProductType> GetProductTypes();
        ProductType GetProductType(int productTypeId);
        bool ProductTypeExists(int productTypeId);
    }
}
