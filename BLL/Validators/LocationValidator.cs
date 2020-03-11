using BusinessLogicalLayer.Extensions;
using DataTransferObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validators
{
   public class LocationValidator : AbstractValidator<LocationDTO>
    {
        public LocationValidator()
        {
            RuleFor(l => l.Value).GreaterThan(0);

            RuleFor(l => l.Vehicle).NotEmpty();

            RuleFor(l => l.EntryTime).LessThan(DateTime.Now);

            RuleFor(l => l.VehicleID).NotEmpty();

        
        }
      

    }
}
