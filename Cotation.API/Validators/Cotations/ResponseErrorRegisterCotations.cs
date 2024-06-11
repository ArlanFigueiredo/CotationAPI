using Cotation.Communication.ModelsViews.Requests.Cotations;

namespace Cotation.API.Validators.Cotations {
    public class ResponseErrorRegisterCotations(ValidatorErrorCotations validator) {
        private readonly ValidatorErrorCotations _validator = validator;

        public async Task<List<ResponseError>> GetErros(RequestCotations request) {
            var validatorCotations = await _validator.ValidateAsync(request);

            var erros = new List<ResponseError>();

            if (!validatorCotations.IsValid) {

                foreach (var error in validatorCotations.Errors) {
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
