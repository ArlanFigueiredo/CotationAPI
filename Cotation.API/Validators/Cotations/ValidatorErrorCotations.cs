using Cotation.Communication.ModelsViews.Requests.Cotations;
using FluentValidation;

namespace Cotation.API.Validators.Cotations {
    public class ValidatorErrorCotations : AbstractValidator<RequestCotations> {

        [Obsolete]
        public ValidatorErrorCotations() {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(cotation => cotation.UserId)
                .NotEmpty()
                .WithMessage("Erro: não foi identificado quem está fazendo a cotação.");

            RuleFor(cotation => cotation.CompanyId)
                .NotEmpty()
                .WithMessage("Erro: não foi identificado para qual empresa está fazendo a cotação.");

        }
    }
}
