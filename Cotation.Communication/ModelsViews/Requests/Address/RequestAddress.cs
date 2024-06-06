namespace Cotation.Communication.ModelsViews.Requests.Address {
    public class RequestAddress {
        public Guid CompanyId { get; set; }
        public int ZipCode { get; set; }
        public string Road { get; set; }
        public string NeighBorHood { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
