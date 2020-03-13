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
        /// <summary>
        ///É uma classe que herda de  AbstractValidator
        ///e passa como parametro ModelDTO e possui um metodo que valida suas propriedades
        /// </summary>
        public ModelValidator()
        {
            RuleFor(c => c.ID).NotEmpty();

            RuleFor(c => c.Name).Length(3, 64);

            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
