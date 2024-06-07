using Cotation.Communication.ModelsViews.Requests.Company;

namespace Cotation.API.Validators.Company {
    public class ResponseErrorRegisterCompany(ValidatorRegisterCompany validator) {
        private readonly ValidatorRegisterCompany _validator = validator;

        public async Task<List<ResponseError>> GetErrors(RequestCompany request) {

            var validatorCompany = await _validator.ValidateAsync(request);

            var erros = new List<ResponseError>();

            if (!validatorCompany.IsValid) {

                foreach (var erro in validatorCompany.Errors) {
                    erros.Add(new ResponseError {
                        PropertyName = erro.PropertyName,
                        ErrorMessage = erro.ErrorMessage,
                    });
                }
            }
            return erros;
        }
    }
}
