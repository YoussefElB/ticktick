using MediatR;
using Microsoft.AspNetCore.Mvc;
using TickTick.App.ResponseWrappers;

namespace TickTick.App.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator mediator;

        public ApiControllerBase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> ExecuteRequest<T>(IRequest<T> request)
        {
            var res = new Response<T>();
            try
            {
                if (request == null)
                {
                    throw new ArgumentException("Sir, Your request is empty.");
                }
                var result = await mediator.Send(request);

                res.Status = System.Net.HttpStatusCode.OK;
                res.Data = result;
            }
            catch (Exception e)
            {

                var error = new string[]
                {
                    e.Message,
                    e.InnerException != null ? e.InnerException.Message : null
                };
                res.Status = System.Net.HttpStatusCode.InternalServerError;
                res.Errors = error;
            }
            return StatusCode((int)res.Status, res);
        }
    }
}
