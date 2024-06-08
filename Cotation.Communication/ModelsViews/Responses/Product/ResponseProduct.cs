using Cotation.Communication.DTOS.ProductDTO;

namespace Cotation.Communication.ModelsViews.Responses.Product {
    public class ResponseProduct {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double PriceUnit { get; set; }

        public ResponseProduct() { }

        public ResponseProduct(DTOProduct dTOProduct) {
            Id = dTOProduct.Id;
            Name = dTOProduct.Name;
            Description = dTOProduct.Description;
            Category = dTOProduct.Category;
            PriceUnit = dTOProduct.PriceUnit;
        }

    }
}
