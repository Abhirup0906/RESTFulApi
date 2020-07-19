using MediatR;
using RESTFulApi.Model.Response;
using System.Collections.Generic;

namespace RESTFulApi.Model.Request
{
    public class GetProductRequest: BaseRequest, IRequest<IEnumerable<GetProductResponse>>
    {
        public int ProductId { get; set; }
    }
}
