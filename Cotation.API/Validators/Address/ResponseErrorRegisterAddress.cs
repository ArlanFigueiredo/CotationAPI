using Cotation.Communication.ModelsViews.Requests.Address;

namespace Cotation.API.Validators.Address {
    public class ResponseErrorRegisterAddress(ValidatorRegisterAddress validator) {
        private readonly ValidatorRegisterAddress _validator = validator;

        public async Task<List<ResponseError>> GetErrors(RequestAddress request) {

            var validatorAddress = await _validator.ValidateAsync(request);

            var erros = new List<ResponseError>();

            foreach (var error in validatorAddress.Errors) {

                erros.Add(new ResponseError { 
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage,
                });
            }
            return erros;
        }
    }
}
