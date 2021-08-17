using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicsORM.Library.Repositories.EF
{
    public class PostalCodeRepository : IPostalCodeRepository
    {
        private readonly ElectronicsDbContext _electronicsDbContext;

        public PostalCodeRepository(ElectronicsDbContext electronicsDbContext)
        {
            _electronicsDbContext = electronicsDbContext;
        }

        public PostalCode GetPostalCode(int postalCodeId)
        {
            var postalCode = _electronicsDbContext.PostalCode.Find(postalCodeId);
            return postalCode;
        }

        public bool PostalCodeExists(int postalCodeId)
        {
            return _electronicsDbContext.PostalCode.Any(p => p.PostalCodeId == postalCodeId);
        }
    }
}
