namespace Cotation.API.Validators {
    public class ResponseError {
        public string? PropertyName { get; set; }
        public string? ErrorMessage { get; set; }

        public ResponseError(string PropertyName, string ErrorMessage) {
            PropertyName = PropertyName;
            ErrorMessage = ErrorMessage;
        }  

        public ResponseError() { }
    }
}
