using Refit;
using System.Runtime.InteropServices;

namespace McNaboe.EntityDataObject.Client
{

    public interface IHttpObjectService<T, TKey> //:IEntityObjectService<T,TKey> where T : class //, IEntityObjectService<T, TKey>
    //
    //public interface IEntityObjectService<T, TKey> where T : class //, IEntityObjectService<T, TKey> 
    {
        [Delete("/{Id}")]
        Task<bool> Delete(TKey Id);

        [Get("/{id}")]
        Task<T> Get(TKey id);

        [Get("")]
        Task<List<T>> GetAll();

        [Post("")]
        Task<T> Insert([Body] T entity);

        [Put("")]
        Task<T> Update([Body] T entityToUpdate);
    }
}
