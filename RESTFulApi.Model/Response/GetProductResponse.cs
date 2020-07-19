using System;

namespace RESTFulApi.Model.Response
{
    public class GetProductResponse
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool? FlagBit { get; set; }
        public bool? FinishedGoodFlag { get; set; }
        public string Color { get; set; }
        public int SafetyStockLevel { get; set; }
        public int ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public DateTime SaleStartDate { get; set; }
        public DateTime? SaleEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
