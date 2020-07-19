using MediatR;
using Microsoft.Extensions.Logging;
using RESTFulApi.Data.Repository;
using RESTFulApi.Model.Request;
using RESTFulApi.Model.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RESTFulApi.Logic.CQRS
{
    public class SearchProduct : IRequestHandler<GetProductRequest, IEnumerable<GetProductResponse>>
    {
        ILogger<SearchProduct> logger;
        IRepository repository;
        public SearchProduct(ILogger<SearchProduct> logger, IRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        public async Task<IEnumerable<GetProductResponse>> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            return await repository.GetProductList(request);
        }
    }
}
