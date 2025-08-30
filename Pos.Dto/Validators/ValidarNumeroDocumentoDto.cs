using FluentValidation;
using Pos.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Dto.Validators
{
    public class ValidarNumeroDocumentoDto : AbstractValidator<NumeroDocumentoDto>
    {
        public ValidarNumeroDocumentoDto()
        {
            RuleFor(d => d.Documento)
            .NotEmpty().WithMessage("No se ha especificado el número del documento.")
            .MaximumLength(10).WithMessage("El número de documento no debe de superar los 10 carácteres.");
        }
    }
}
