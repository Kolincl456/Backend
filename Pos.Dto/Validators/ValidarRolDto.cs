using FluentValidation;
using Pos.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Dto.Validators
{
    public class ValidarRolDto : AbstractValidator<RolDto>
    {
        public ValidarRolDto() {
            RuleFor(r => r.Descripcion)
                .NotEmpty().WithMessage("Es necesario especificar le descripción del rol.")
                .MaximumLength(50).WithMessage("La descripción del rol no debe de superar los 50 carácteres.");

            RuleFor(r => r.Estado)
                .NotEmpty().WithMessage("Es necesario especificar el estado del rol.")
                .MaximumLength(8).WithMessage("El estado del rol no debe de superar los 8 caracters.")
                .Must(estado => estado == "Activo" || estado == "Inactivo").WithMessage("El estado debe ser 'activo' o 'Inactivo'.");
        }
    }
}
