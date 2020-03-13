using DataTransferObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validators
{
    /// <summary>
    ///É uma classe que herda de  AbstractValidator
    ///e passa como parametro BrandDTO, e possui um metodo que valida suas propriedades
    /// </summary>
    class BrandValidator : AbstractValidator<CLientDTO>
    {
        public BrandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();

            RuleFor(c => c.Name).Length(1, 64);

            RuleFor(c => c.ID).Must(c => c >= 0);
        }
    }
}
