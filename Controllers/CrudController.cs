using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApi.Requests;


namespace RestApi.Controllers {
    public abstract class CrudController<TKey, TEntity, TGetSingleModel, TGetListModel, TPutModel, TPostModel> : 
        BaseController where TEntity : class {

        public CrudController(
            ILogger<CrudController<TKey, TEntity, TGetSingleModel, TGetListModel, TPutModel, TPostModel>> logger, 
            IMediator mediator) : 
            base(logger, mediator) {
        }

        [HttpPost()]
        public virtual async Task<IActionResult> CreateAsync([FromBody] TPostModel model) { 
            return await HandleRequestAsync(new PostRequest<TKey, TEntity, TPostModel, TGetSingleModel> {
                Model = model
            });
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

        [HttpPut("{key}")]
        public virtual async Task<IActionResult> UpdateAsync(TKey key, [FromBody] TPutModel model) {
            return await HandleRequestAsync(new PutRequest<TKey, TEntity, TPutModel, TGetSingleModel> {
                Key = key,
                Model = model
            });
        }

        [HttpDelete("{key}")]
        public virtual async Task<IActionResult> DeleteAsync(TKey key) {
            return await HandleRequestAsync(new DeleteRequest<TKey, TEntity> {
                Key = key
            });
        }

    }
}