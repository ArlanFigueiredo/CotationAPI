using Cotation.Communication.ModelsViews.Requests.User;

namespace Cotation.API.Validators.User {
    public class ResponseErrorRegisterUser(ValidatorRegisterUser validator) {
        private readonly ValidatorRegisterUser _validator = validator;

        public async Task<List<ResponseError>> GetErros(RequestUser request) {
            var validatorUser = await _validator.ValidateAsync(request);

            var erros = new List<ResponseError>();

            if (!validatorUser.IsValid) {

                foreach (var error in validatorUser.Errors) {
                    erros.Add(new ResponseError(error.PropertyName, error.ErrorMessage));
                }
            }

            return erros;
        }
    }
}
