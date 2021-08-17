using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsORM.Library.Interfaces
{
    public interface IStoreRepository
    {
        Store Getstore(int storeId);
        bool StoreExists(int storeId);
    }
}
