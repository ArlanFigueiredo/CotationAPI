using Cotation.Communication.ModelsViews.Requests.Address;

namespace Cotation.Communication.DTOS.AddressDTO {
    public class DTOAddress {

        public Guid Id { get; set; } 
        public Guid CompanyId { get; set; }
        public int ZipCode { get; set; }
        public string Road { get; set; }
        public string NeighBorHood { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }

        public DTOAddress(RequestAddress request) {
            CompanyId = request.CompanyId;
            ZipCode = request.ZipCode;
            Road = request.Road;
            NeighBorHood = request.NeighBorHood;
            Number = request.Number;
            City = request.City;
            State = request.State;
        }
        public DTOAddress() { }
    }
}
