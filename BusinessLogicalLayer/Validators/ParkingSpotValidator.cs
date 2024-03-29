﻿using DataTransferObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validators
{
    public class ParkingSpotValidator : AbstractValidator<ParkingSpotDTO>
    {
        public ParkingSpotValidator()
        {
            RuleFor(c => c.Type).IsInEnum();
            RuleFor(c => c.ValuePerHour).Empty();
            RuleFor(c => c.ValuePerHour).GreaterThan(0);
            RuleFor(c => c.ID).Empty();
            RuleFor(c => c.IsActive).Equal(true);
        }
    }
}
