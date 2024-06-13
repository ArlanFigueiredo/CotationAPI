namespace Cotation.Application.Interfaces.Company {
    public interface IDeleteCompanyService {
        public Task<string> Execute(Guid id);
    }
}
