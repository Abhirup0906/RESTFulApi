using RESTFulApi.Model.Request;
using RESTFulApi.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTFulApi.Data.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<GetProductResponse>> GetProductList(GetProductRequest request);
    }
}
