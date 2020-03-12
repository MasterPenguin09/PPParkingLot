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
        /// <summary>
        ///É uma classe que herda de  AbstractValidator
        ///e passa como parametro LocationDTO e possui um metodo que valida suas propriedades
        /// </summary>
        public LocationValidator()
        {
            RuleFor(l => l.Value).GreaterThan(0);

            RuleFor(l => l.Vehicle).NotEmpty();

            RuleFor(l => l.EntryTime).GreaterThan(DateTime.Now);

            RuleFor(l => l.VehicleID).NotEmpty();

        
        }
      

    }
}
