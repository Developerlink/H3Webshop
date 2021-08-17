using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicsORM.Library.Repositories.EF
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ElectronicsDbContext _electronicsDbContext;

        public StoreRepository(ElectronicsDbContext electronicsDbContext)
        {
            _electronicsDbContext = electronicsDbContext;
        }

        public Store Getstore(int storeId)
        {
            throw new NotImplementedException();
        }

        public bool StoreExists(int storeId)
        {
            return _electronicsDbContext.Store.Any(s => s.Id == storeId);
        }
    }
}
