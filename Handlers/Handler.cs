using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RestApi.Requests;


namespace RestApi.Handlers {
    public abstract class Handler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> 
        where TRequest : Request<TResponse> {
        
        public async Task<TResponse> Handle(TRequest message, CancellationToken cancellationToken) {
            return await ExecuteAsync(message, cancellationToken);        
        }

        protected abstract Task<TResponse> ExecuteAsync(TRequest message, CancellationToken cancellationToken);

    }
}