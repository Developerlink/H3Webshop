using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsORM.Library.Interfaces
{
    public interface IPostalCodeRepository
    {
        PostalCode GetPostalCode(int postalCodeId);
        bool PostalCodeExists(int postalCodeId);
    }
}
