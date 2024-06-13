using Cotation.Communication.ModelsViews.Requests.Company;
using Cotation.Communication.ModelsViews.Responses.Company;

namespace Cotation.Application.Interfaces.Company {
    public interface IUpdateCompanyService {
        public Task<ResponseCompany> Execute(RequestCompany request, Guid id);
    }
}
