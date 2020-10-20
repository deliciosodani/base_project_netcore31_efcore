using eClinica.Models.Atenciones.AtencionesDelDia;
using FluentValidation;

namespace eClinica.WebApi.Validators
{
    public class AtencionDelDiaValidator : AbstractValidator<AtencionDelDiaRequestModel>
    {
        public AtencionDelDiaValidator()
        {
            RuleFor(a => a.Documento)
                .NotEmpty()
                .WithMessage("El Documento no debe quedar en blanco.");

            RuleFor(a => a.NombreCliente)
                .MaximumLength(50)
                .WithMessage("La longitud máxima del Nombre del Cliente es de {MaxLength} caracteres.");            
        }
    }
}