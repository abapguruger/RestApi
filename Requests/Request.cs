using System;
using System.Linq;
using System.Security.Claims;
using MediatR;


namespace RestApi.Requests {
    public abstract class Request<TReturn> : IRequest<TReturn> {

        public ClaimsPrincipal ClaimsPrincipal { get; set; }

        public Guid GetUserId() {

            if (ClaimsPrincipal == null)
                return Guid.Empty;

            return Guid.Parse(ClaimsPrincipal.Claims.First(c => c.Type == ClaimTypes.Name).Value);
            
        }

    }
}