using FluentValidation;
using Pos.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Dto.Validators
{
    public class ValidarProductoDto : AbstractValidator<ProductoDto>
    {
        public ValidarProductoDto() {
            RuleFor(p => p.CodigoBarra)
            .NotEmpty().WithMessage("Es necesario especificar el código de barra.")
            .MaximumLength(30).WithMessage("El código de barra no debe de superar los 30 caracteres.");

            RuleFor(p => p.CodigoBarra)
            .NotEmpty().WithMessage("Debe especificar la descripción del producto.")
            .MaximumLength(50).WithMessage("El nombre del producto no debe de superar los 50 caracteres.");

            RuleFor(p => p.IdCategoria)
            .GreaterThan(0).WithMessage("Debe seleccionar una categoría válida.");

            RuleFor(p => p.PrecioVenta)
            .GreaterThanOrEqualTo(0).WithMessage("El precio de venta debe ser mayor a cero.");

            RuleFor(p => p.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser menor a cero.");

            RuleFor(p => p.StockMinimo)
            .GreaterThan(0).WithMessage("El stock mínimo debe ser mayor a cero.");

            RuleFor(r => r.Estado)
            .NotEmpty().WithMessage("Es necesario especificar el estado del producto.")
            .MaximumLength(8).WithMessage("El estado del producto no debe de superar los 8 caracters.")
            .Must(estado => estado == "Activo" || estado == "Inactivo").WithMessage("El estado debe ser 'activo' o 'Inactivo'.");

        }
    }
}
