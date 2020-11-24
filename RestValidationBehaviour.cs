using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;


namespace RestApi {
    public class RestValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> {
        
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators) : 
            base() {
            _validators = validators;
        }

        public Task<TResponse> Handle(
            TRequest request, 
            CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponse> next) {

            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(r => r.Validate(context))
                .SelectMany(a => a.Errors)
                .Where(x => x != null);

            if (failures.Any())
                throw new ValidationException(failures);

            return next();
            
        }

    }
}