using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces_EFCore_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Impl
{
   public class BrandService : IBrandService
    {
        private IBrandRepository _iBrandRepository;
        public BrandService(IBrandRepository iBrandRep)
        {
            this._iBrandRepository = iBrandRep;
        }
    }
}
