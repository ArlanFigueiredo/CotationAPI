using Cotation.Communication.ModelsViews.Requests.Item;
using FluentValidation;

namespace Cotation.API.Validators.Item {
    public class ValidatorRegisterItem : AbstractValidator<RequestItem> {

        [Obsolete]
        public ValidatorRegisterItem() {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(item => item.CompanyId)
                .NotEmpty()
                .WithMessage("Erro: Não foi identificado para quem o Item está sendo criado.");

            RuleFor(item => item.ProductId)
               .NotEmpty()
               .WithMessage("Erro: Não foi identificado o produto.");

            RuleFor(item => item.Quantity)
               .NotEmpty()
               .WithMessage("O campo Quantidade é obrigatorio. Por favor, preencha-o");

            RuleFor(item => item.Quantity)
               .GreaterThan(0)
               .WithMessage("A quantidade deve ser pelo menos 1");
        }
    }
}
