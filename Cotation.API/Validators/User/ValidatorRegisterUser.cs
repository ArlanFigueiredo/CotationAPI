using Cotation.Communication.ModelsViews.Requests.User;
using FluentValidation;

namespace Cotation.API.Validators.User {
    public class ValidatorRegisterUser : AbstractValidator<RequestUser> {

        [Obsolete]
        public ValidatorRegisterUser() {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage("O campo Nome é obrigatorio. Por favor, preencha-o.");

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("O campo Email é obrigatorio. Por favor, preencha-o.");

            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("O campo Password é obrigatorio. Por favor, preencha-o.");
        }
    }
}
