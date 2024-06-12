namespace Cotation.Application.Interfaces.Product {
    public interface IDeleteProductService {
        public Task<string> Execute(Guid id);
    }
}
