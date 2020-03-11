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
    class VehicleValidator : AbstractValidator<VehicleDTO>
    {
        public VehicleValidator()
        {
            RuleFor(c => c.Model).NotEmpty();
            RuleFor(c => c.CarBoard).NotEmpty(); 
            RuleFor(c => c.ModelID).NotEmpty();
            RuleFor(c => c.CarBoard.VBoard()).Equal(true);
        }
    }
}
