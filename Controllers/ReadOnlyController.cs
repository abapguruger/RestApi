using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApi.Requests;


namespace RestApi.Controllers {
    public abstract class ReadOnlyController<TKey, TEntity, TGetSingleModel, TGetListModel> : 
        BaseController where TEntity : class {
        
        public ReadOnlyController(
            ILogger<ReadOnlyController<TKey, TEntity, TGetSingleModel, TGetListModel>> logger, 
            IMediator mediator) : 
            base(logger, mediator) {
        }

        [HttpGet()]
        public virtual async Task<IActionResult> ReadAsync() {
            return await HandleRequestAsync(new GetListRequest<TKey, TEntity, TGetListModel> {
                Query = HttpContext.Request.Query
            });
        }

        [HttpGet("{key}")]
        public virtual async Task<IActionResult> ReadAsync(TKey key) {
            return await HandleRequestAsync(new GetSingleRequest<TKey, TEntity, TGetSingleModel> {
                Query = HttpContext.Request.Query,
                Key = key
            });
        }

    }
}