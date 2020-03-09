using DataTransferObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validators
{
    class ClientValidator : AbstractValidator<ClientDTO>
    {
        public ClientValidator()
        {
            RuleFor(c => c.BirthDate).LessThan(DateTime.Now);
            RuleFor(c => c.Name).Length(3,64);
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.AccessLevel).IsInEnum();
        }
    }
}
