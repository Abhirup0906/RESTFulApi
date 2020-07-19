using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTFulApi.Logic.Saga.Interface;
using RESTFulApi.Model.Request;
using RESTFulApi.Model.Response;

namespace RESTFulApi.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ILogger<ProductController> logger;
        Lazy<ISagaHandler<GetProductRequest, GenericResponse<IEnumerable<GetProductResponse>>>> getProdHandler;
        
        public ProductController(ILogger<ProductController> logger, 
            Lazy<ISagaHandler<GetProductRequest,GenericResponse<IEnumerable<GetProductResponse>>>> getProdHandler)
        {
            this.logger = logger;
            this.getProdHandler = getProdHandler;            
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]         
        public async Task<ActionResult<GenericResponse<IEnumerable<GetProductResponse>>>> Get()
        {
            try
            {
                return await getProdHandler.Value.Execute(new GetProductRequest() { });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
