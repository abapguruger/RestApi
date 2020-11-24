using System;


namespace RestApi.Requests {

    public class DeleteRequest<TKey, TEntity> : Request<object> where TEntity : class {

        public TKey Key { get; set; }
        
    }

    public class DeleteRequest<TKeyTop, TKey, TEntity> : DeleteRequest<TKey, TEntity> where TEntity : class {

        public TKeyTop KeyTop { get; set; }

    }

}