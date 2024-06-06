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
    }
}
