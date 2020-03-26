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
    class EmployeeValidator : AbstractValidator<EmployeeDTO>
    {
        /// <summary>
        ///É uma classe que herda de  AbstractValidator
        ///e passa como parametro EmployeeDTO e possui um metodo que valida suas propriedades
        /// </summary>
        public EmployeeValidator()
        {
            RuleFor(c => c.BirthDate).LessThan(DateTime.Now);

            RuleFor(c => c.Name).Length(4, 128);

            RuleFor(c => c.Name).NotEmpty();

            RuleFor(c => c.AccessLevel).IsInEnum();

            RuleFor(c => c.Email.EmailIsValid());

            RuleFor(c => c.CPF.IsCpf());
        }
     
    }
}
