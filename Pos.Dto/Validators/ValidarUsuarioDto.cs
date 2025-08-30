using FluentValidation;
using Pos.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Dto.Validators
{
    public class ValidarUsuarioDto : AbstractValidator<UsuarioDto>
    {
        public ValidarUsuarioDto() {
            RuleFor(u => u.Nombres)
            .NotEmpty().WithMessage("Es necesario especificar el nombre del usuario.")
            .MaximumLength(35).WithMessage("El nombre del usuario no debe superar los 35 carácteres.");

            RuleFor(u => u.Apellidos)
            .NotEmpty().WithMessage("Es necesario especificar el apellido del usuario.")
            .MaximumLength(35).WithMessage("El apellido del usuario no debe superar los 35 carácteres.");

            RuleFor(u => u.IdRol)
            .GreaterThan(0).WithMessage("Debe seleccionar un rol válido.");

            RuleFor(u => u.Telefono)
            .NotEmpty().WithMessage("Es necesario especificar el número de teléfono.")
            .WithMessage("El número de teléfono debe contener al menos 8 caráctes.")
            .MaximumLength(50).WithMessage("El número de teléfono no debe superar los 15 carácteres.");

            RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Es necesario especificar el email.")
            .MaximumLength(50).WithMessage("El email no debe de superar los 50 carácteres.");

            RuleFor(u => u.Clave)
            .NotEmpty().WithMessage("Es necesario especificar la contraseña del usuario.")
            .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 carácteres.");

            RuleFor(u => u.Estado)
            .NotEmpty().WithMessage("Es necesario especificar el estado del usuario.")
            .MaximumLength(8).WithMessage("El estado del usuario no debe de superar los 8 carácteres.")
            .Must(estado => estado == "Activo" || estado == "Inactivo").WithMessage("El estado debe ser 'Activo' o 'Inactivo'.");
        }
        
    }
}
