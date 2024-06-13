using Cotation.Communication.ModelsViews.Responses.Company;

namespace Cotation.Application.Interfaces.Company {
    public interface IGetCompanyByIdService {
        public Task<ResponseCompany> Execute(Guid id);
    }
}
