using MediatR;
using RESTFulApi.Logic.Saga.Interface;
using RESTFulApi.Model.Request;
using RESTFulApi.Model.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RESTFulApi.Logic.Saga.Impl
{
    public class GetProductSaga : ISagaHandler<GetProductRequest, GenericResponse<IEnumerable<GetProductResponse>>>
    {
        IMediator mediator; 
        public GetProductSaga(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<GenericResponse<IEnumerable<GetProductResponse>>> Execute(GetProductRequest request)
        {
            var response = new GenericResponse<IEnumerable<GetProductResponse>>();
            response.Data =  await mediator.Send(request,CancellationToken.None);
            return response;
        }
    }
}
