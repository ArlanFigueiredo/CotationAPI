using Cotation.Communication.DTOS.AddressDTO;

namespace Cotation.Communication.ModelsViews.Responses.Address {
    public class ResponseAddress {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public int ZipCode { get; set; }
        public string Road { get; set; }
        public string NeighBorHood { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public ResponseAddress(DTOAddress dtoAddress) { 
            CompanyId = dtoAddress.CompanyId;
            ZipCode = dtoAddress.ZipCode;
            Road = dtoAddress.Road;
            NeighBorHood = dtoAddress.NeighBorHood;
            Number = dtoAddress.Number;
            City = dtoAddress.City;
            State = dtoAddress.State;
        }

        public ResponseAddress() { }
    }
}
