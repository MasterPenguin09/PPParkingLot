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
        /// <summary>
        ///É uma classe que herda de  AbstractValidator
        ///e passa como parametro VehicleDTO e possui um metodo que valida suas propriedades
        /// </summary>
        public VehicleValidator()
        {
            RuleFor(c => c.Model).NotEmpty();
            RuleFor(c => c.CarBoard).NotEmpty(); //TODO: Fazer uma validação decente para a placa
            RuleFor(c => c.ModelID).NotEmpty();
        }
    }
}
