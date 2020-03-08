using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces_EFCore_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Impl
{
   public class LocationService : ILocationSevice
    {
        private ILocationRepository _iLocationRepository;
        public LocationService(ILocationRepository iLocationRep)
        {
            this._iLocationRepository = iLocationRep;
        }

    }
}
