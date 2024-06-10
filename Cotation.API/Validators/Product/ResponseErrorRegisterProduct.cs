using Cotation.Communication.ModelsViews.Requests.Product;

namespace Cotation.API.Validators.Product {
    public class ResponseErrorRegisterProduct(ValidatorRegisterProduct validator) {
        private readonly ValidatorRegisterProduct _validator = validator;

        public async Task<List<ResponseError>> GetErrors(RequestProduct request) {
            var validatorProduct = await _validator.ValidateAsync(request);

            var erros = new List<ResponseError>();

            if (!validatorProduct.IsValid) {
                foreach (var error in validatorProduct.Errors) {

                    erros.Add(new ResponseError {
                        PropertyName = error.PropertyName,
                        ErrorMessage = error.ErrorMessage,
                    });
                }
            }
            return erros;
        }
    }
}
