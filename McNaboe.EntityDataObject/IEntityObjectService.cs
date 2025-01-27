namespace McNaboe.EntityDataObject
{
    public interface IEntityObjectService<T, TKey> where T : class

    {

        Task<bool> Delete(TKey Id);
        Task<T> Get(TKey id);
        Task<List<T>> GetAll();
        Task<IQueryable<T>> GetAllAsQueryable();
        Task<T> Insert(T entity);
        Task<T> Update(T entityToUpdate);
    }
    public interface IIntKeyObjectService<T> : IEntityObjectService<T, int> where T : class
    {

    }

    public interface IStringKeyObjectService<T> : IEntityObjectService<T, string> where T : class
    {

    }




    //public interface IQueryableEntityObjectService<T, TKey> where T : class

    //{

    //    Task<bool> Delete(TKey Id);
    //    Task<T> Get(TKey id);
    //    Task<IQueryable<T>> GetAll();
    //    Task<T> Insert(T entity);
    //    Task<T> Update(T entityToUpdate);
    //}
    //public interface IQueryabeIntKeyObjectService<T> : IQueryableEntityObjectService<T, int> where T : class
    //{

    //}

    //public interface IQueryableStringKeyObjectService<T> : IQueryableEntityObjectService<T, string> where T : class
    //{

    //}

}

