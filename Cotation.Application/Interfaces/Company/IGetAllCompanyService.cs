using Cotation.Communication.ModelsViews.Responses.Company;

namespace Cotation.Application.Interfaces.Company {
    public interface IGetAllCompanyService {
        public Task<List<ResponseCompany>> Execute();
    }
}
