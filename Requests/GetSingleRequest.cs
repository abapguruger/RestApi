using System;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace RestApi.Requests {
    
    public class GetSingleRequest<TKey, TEntity, TModel> : Request<TModel> where TEntity : class {

        public IQueryCollection Query { get; set; }

        public TKey Key { get; set; }

    }

    public class GetSingleRequest<TKeyTop, TKey, TEntity, TModel> : GetSingleRequest<TKey, TEntity, TModel> where TEntity : class {

        public TKeyTop KeyTop { get; set; }
        
    }

}