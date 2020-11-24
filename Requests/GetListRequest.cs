using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;


namespace RestApi.Requests {

    public class GetListRequest<TKey, TEntity, TModel> : Request<IEnumerable<TModel>> where TEntity : class  {

        public IQueryCollection Query { get; set; }

    }

    public class GetListRequest<TKeyTop, TKey, TEntity, TModel> : GetListRequest<TKey, TEntity, TModel> where TEntity : class {

        public TKeyTop KeyTop { get; set; }

    }

}