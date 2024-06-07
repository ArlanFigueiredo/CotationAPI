using Cotation.Communication.ModelsViews.Requests.Company;
using FluentValidation;

namespace Cotation.API.Validators.Company {
    public class ValidatorRegisterCompany : AbstractValidator<RequestCompany> {

        [Obsolete]
        public ValidatorRegisterCompany() {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(company => company.Name)
                .NotEmpty()
                .WithMessage("O campo Empresa é obrigatorio. Por favor, preencha-o");

            RuleFor(company => company.Cnpj)
                .NotEmpty()
                .WithMessage("O campo CNPJ é obrigatorio. Por favor, preencha-o");

            RuleFor(company => company.Phone)
                .NotEmpty()
                .WithMessage("O campo Celular é obrigatorio. Por favor, preencha-o");

            RuleFor(company => company.Email)
                .NotEmpty()
                .WithMessage("O campo Email é obrigatorio. Por favor, preencha-o");
        }
    }
}
