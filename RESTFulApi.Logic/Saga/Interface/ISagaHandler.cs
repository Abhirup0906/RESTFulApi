using RESTFulApi.Model.Request;
using RESTFulApi.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RESTFulApi.Logic.Saga.Interface
{
    public interface ISagaHandler<in T, U> where T: BaseRequest
                                                
    {
        Task<U> Execute(T request);
    }
}
