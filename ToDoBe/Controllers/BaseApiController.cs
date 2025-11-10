using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Wolverine;

namespace ToDoBe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected readonly IMessageBus messageBus;

        public BaseApiController(IMessageBus messageBus)
        {
            this.messageBus = messageBus;
        }
        protected async Task<ActionResult<BaseResponse<TResponse>>> ExecuteRequest<TRequest, TResponse>(TRequest request)
        {
            if (request is null)
            {
                return BadRequest(new BaseResponse
                (
                    HttpStatusCode.BadRequest,
                    "Request cannot be null."
                )
                {
                    IsSuccess = false
                });
            }
            var result = await messageBus.InvokeAsync<BaseResponse<TResponse>>(request);
            return result.StatusCode switch
            {
                HttpStatusCode.OK => Ok(result),
                HttpStatusCode.Created => Created("", result),
                HttpStatusCode.Accepted => Accepted(result),
                HttpStatusCode.NotFound => NotFound(result),
                HttpStatusCode.BadRequest => BadRequest(result),
                HttpStatusCode.Conflict => Conflict(result),
                _ => BadRequest(result),
            };
        }
        protected async Task<ActionResult<BaseResponse>> ExecuteRequest<TRequest>(TRequest request)
        {
            if (request is null)
            {
                return BadRequest(new BaseResponse
                (
                    HttpStatusCode.BadRequest,
                    "Request cannot be null."
                )
                {
                    IsSuccess = false
                });
            }

            var result = await messageBus.InvokeAsync<BaseResponse>(request);
            return result.StatusCode switch
            {
                HttpStatusCode.OK => Ok(result),
                HttpStatusCode.Created => Created("", result),
                HttpStatusCode.Accepted => Accepted(result),
                HttpStatusCode.NotFound => NotFound(result),
                HttpStatusCode.BadRequest => BadRequest(result),
                HttpStatusCode.Conflict => Conflict(result),
                _ => BadRequest(result),
            };
        }
    }
}
