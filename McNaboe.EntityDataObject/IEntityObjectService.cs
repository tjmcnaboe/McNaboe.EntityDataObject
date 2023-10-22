namespace McNaboe.EntityDataObject
{
    public interface IEntityObjectService<T, TKey> where T : class

    {

        Task<bool> Delete(TKey Id);
        Task<T> Get(TKey id);
        Task<List<T>> GetAll();
        Task<T> Insert(T entity);
        Task<T> Update(T entityToUpdate);
    }
    public interface IIntKeyObjectService<T> : IEntityObjectService<T, int> where T : class
    {

    }

    public interface IStringKeyObjectService<T> : IEntityObjectService<T, string> where T : class
    {

    }
}
