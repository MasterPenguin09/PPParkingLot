using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces_EFCore_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Impl
{
   public class VehicleService : IVehicleService
    {
        private IVehicleRepository _iVehicleRepository;
        public VehicleService(IVehicleRepository iVehicleRep)
        {
            this._iVehicleRepository = iVehicleRep;
        }


    }
}
