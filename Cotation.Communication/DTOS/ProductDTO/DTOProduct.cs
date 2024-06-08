using Azure.Core;
using Cotation.Communication.ModelsViews.Requests.Product;

namespace Cotation.Communication.DTOS.ProductDTO {
    public class DTOProduct {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double PriceUnit { get; set; }
        public DateTime CreatedAt { get; set; }

        public DTOProduct(RequestProduct request) {
            Name = request.Name;
            Description = request.Description;
            Category = request.Category;
            PriceUnit = request.PriceUnit;
        }

        public DTOProduct() { } 
    }
}
