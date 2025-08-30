using FluentValidation;
using Pos.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Dto.Validators
{
    public class ValidarNegocioDto : AbstractValidator<NegocioDto>
    {
        public ValidarNegocioDto() {
            RuleFor(n => n.RUC)
            .NotEmpty().WithMessage("Es necesario especificar el número RUC de la empresa.")
            .MaximumLength(20).WithMessage("El número RUC no debe de superar los 20 carácteres.");

            RuleFor(n => n.RazonSocial)
            .NotEmpty().WithMessage("Es necesario especificar el nombre de la empresa.")
            .MaximumLength(50).WithMessage("El nombre no debe de superar los 50 carácteres.");

            RuleFor(n => n.Email)
            .NotEmpty().WithMessage("Es necesario especificar el email de la empresa.")
            .MaximumLength(50).WithMessage("El email no debe de superar los 50 carácteres.");

            RuleFor(u => u.Telefono)
            .NotEmpty().WithMessage("Es necesario especificar el número de teléfono.")
            .MinimumLength(8).WithMessage("El número de teléfono debe de contener al menos 8 carácteres.")
            .MaximumLength(15).WithMessage("El número de teléfono no debe de superar los 15 carácteres.");

            RuleFor(u => u.Direccion)
            .NotEmpty().WithMessage("Es necesario especificar la dirección de la empresa")
            .MaximumLength(50).WithMessage("La dirección no debe de superar los 50 carácteres.");

            RuleFor(u => u.Propietario)
            .NotEmpty().WithMessage("Es necesario especificar el propietario de la empresa.")
            .MinimumLength(3).WithMessage("El nombre del propietario debe contener al menos 3 carácteres.")
            .MaximumLength(50).WithMessage("El nombre del propietario no debe superar los 50 carácteres.");

            RuleFor(u => u.Descuento)
            .NotEmpty().WithMessage("Es necesario especificar el descuento.")
            .GreaterThanOrEqualTo(0).WithMessage("El descuento no puede ser menor a cero.");
        }
    }
}
