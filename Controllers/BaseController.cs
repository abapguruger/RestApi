using System;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApi.Requests;


namespace RestApi.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController()]
    public abstract class BaseController : Controller {

        protected readonly ILogger<BaseController> _logger;

        protected readonly IMediator _mediator;

        public BaseController(ILogger<BaseController> logger, IMediator mediator) : 
            base() {
            _logger = logger;
            _mediator = mediator;
        }

        protected async Task<IActionResult> HandleRequestAsync<TReturn>(Request<TReturn> request) {

            // logging
            _logger.LogDebug("New Request {0}", request.ToString());

            // exit if no request
            if (request == null) {
                _logger.LogError("Empty Request");
                return BadRequest("Empty Request");
            }

            // add user principal
            if (HttpContext.User != null)
                request.ClaimsPrincipal = HttpContext.User;

            // handle request
            try {
                return Ok(await _mediator.Send(request));

            } catch (ValidationException e) {
                _logger.LogWarning(e, "BadRequest");
                return BadRequest(e.Message);

            } catch (UnauthorizedAccessException e) {
                _logger.LogWarning(e, "Forbidden");
                return Forbid();

            } catch (InvalidOperationException e) {
                _logger.LogWarning(e, "NotFound");
                return NotFound();

            } catch (Exception e) {
                _logger.LogWarning(e, "BadRequest");
                return Problem(e.Message);
                
            }

        }

    }
}