using DataTransferObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validators
{
    class ModelValidator : AbstractValidator<ModelDTO>
    {
        public ModelValidator()
        {
            RuleFor(c => c.ID).NotEmpty();
            RuleFor(c => c.Name).Length(3, 64);
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
