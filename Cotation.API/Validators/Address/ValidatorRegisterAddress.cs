using Cotation.Communication.ModelsViews.Requests.Address;
using FluentValidation;

namespace Cotation.API.Validators.Address {
    public class ValidatorRegisterAddress : AbstractValidator<RequestAddress> {

        [Obsolete]
        public ValidatorRegisterAddress() {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(a => a.ZipCode)
                .NotEmpty()
                .WithMessage("O campo CEP é obrigatorio. Por favor, preencha-o");

            RuleFor(a => a.Road)
                .NotEmpty()
                .WithMessage("O campo Rua é obrigatorio. Por favor, preencha-o");

            RuleFor(a => a.NeighBorHood)
                .NotEmpty()
                .WithMessage("O campo Bairro é obrigatorio. Por favor, preencha-o");

            RuleFor(a => a.Number)
                .NotEmpty()
                .WithMessage("O campo Numero é obrigatorio. Por favor, preencha-o");

            RuleFor(a => a.City)
                .NotEmpty()
                .WithMessage("O campo Cidade é obrigatorio. Por favor, preencha-o");

            RuleFor(a => a.State)
                .NotEmpty()
                .WithMessage("O campo Estado é obrigatorio. Por favor, preencha-o");
        }
    }
}
