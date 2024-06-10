using Cotation.Communication.ModelsViews.Requests.Product;
using FluentValidation;

namespace Cotation.API.Validators.Product {
    public class ValidatorRegisterProduct : AbstractValidator<RequestProduct> {

        [Obsolete]
        public ValidatorRegisterProduct() {
            CascadeMode = CascadeMode.StopOnFirstFailure;


            RuleFor(product => product.Name)
                .NotEmpty()
                .WithMessage("O campo Nome é obrigatorio. Por favor, preencha-o");

            RuleFor(product => product.Description)
                .NotEmpty()
                .WithMessage("O campo Descrição é obrigatorio. Por favor, preencha-o");

            RuleFor(product => product.Category)
                 .NotEmpty()
                 .WithMessage("O campo Categoria é obrigatorio. Por favor, preencha-o");

            RuleFor(product => product.PriceUnit)
                .NotEmpty()
                .WithMessage("O campo Preço Unico é obrigatorio. Por favor, preencha-o");

        }
    }
}
