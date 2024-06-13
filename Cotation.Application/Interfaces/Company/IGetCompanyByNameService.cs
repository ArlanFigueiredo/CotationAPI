using Cotation.Communication.ModelsViews.Responses.Company;

namespace Cotation.Application.Interfaces.Company {
    public interface IGetCompanyByNameService {

        public Task<ResponseCompany> Execute(string name);
    }
}
