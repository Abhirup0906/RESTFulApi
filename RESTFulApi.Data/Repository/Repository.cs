using Microsoft.EntityFrameworkCore;
using RESTFulApi.Data.DbModels;
using RESTFulApi.Model.Request;
using RESTFulApi.Model.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTFulApi.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly AdventureWorks2017Context context;
        public Repository(AdventureWorks2017Context context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<GetProductResponse>> GetProductList(GetProductRequest request)
        {
            return await context.Product.Where(prod => (request.ProductId == 0) ? true : prod.ProductId == request.ProductId)
                                .Select(prod => new GetProductResponse()
                                {
                                    ProductId = prod.ProductId,
                                    Class = prod.Class,
                                    Color = prod.Color,
                                    DaysToManufacture = prod.DaysToManufacture,
                                    DiscontinuedDate = prod.DiscontinuedDate,
                                    FinishedGoodFlag = prod.FinishedGoodsFlag,
                                    FlagBit = prod.MakeFlag,
                                    ListPrice = prod.ListPrice,
                                    ModifiedDate = prod.ModifiedDate,
                                    Name = prod.Name,
                                    ProductLine = prod.ProductLine,
                                    ProductNumber = prod.ProductNumber,
                                    ReorderPoint = prod.ReorderPoint,
                                    SafetyStockLevel = prod.SafetyStockLevel,
                                    SaleEndDate = prod.SellEndDate,
                                    SaleStartDate = prod.SellStartDate,
                                    Size = prod.Size,
                                    StandardCost = prod.StandardCost,
                                    Style = prod.Style,
                                    Weight = prod.Weight
                                }).ToListAsync();
        }
    }
}
