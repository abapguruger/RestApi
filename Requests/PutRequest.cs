using System;


namespace RestApi.Requests {

    public class PutRequest<TKey, TEntity, TInputModel, TOutputModel> : Request<TOutputModel> where TEntity : class {

        public TKey Key { get; set; }

        public TInputModel Model { get; set; }

    }

    public class PutRequest<TKeyTop, TKey, TEntity, TInputModel, TOutputModel> : PutRequest<TKey, TEntity, TInputModel, TOutputModel> where TEntity : class {

        public TKeyTop KeyTop { get; set; }

    }

}