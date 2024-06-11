using Cotation.Communication.ModelsViews.Requests.Item;

namespace Cotation.API.Validators.Item {
    public class ResponseErrorRegisterItem(ValidatorRegisterItem validator) {
        private readonly ValidatorRegisterItem _validator = validator;

        public async Task<List<ResponseError>> GetErros(RequestItem request) {

            var validatorItem = await _validator.ValidateAsync(request);

            var error = new List<ResponseError>();

            if (validatorItem.IsValid) {

                foreach (var erros in validatorItem.Errors) {

                    error.Add(new ResponseError {
                        PropertyName = erros.PropertyName,
                        ErrorMessage = erros.ErrorMessage,
                    });
                }
            }
            return error;
        }
    }
}
