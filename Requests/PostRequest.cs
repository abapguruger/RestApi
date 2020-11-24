using System;


namespace RestApi.Requests {

    public class PostRequest<TKey, TEntity, TInputModel, TOutputModel> : Request<TOutputModel> where TEntity : class {

        public TInputModel Model { get; set; }

    }

    public class PostRequest<TKeyTop, TKey, TEntity, TInputModel, TOutputModel> : PostRequest<TKey, TEntity, TInputModel, TOutputModel> where TEntity : class {

        public TKeyTop KeyTop { get; set; }

    }

}