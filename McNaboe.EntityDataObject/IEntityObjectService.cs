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



    public interface IEntityObjectMapper<T,TVM> where T : class
    {
        TVM MapOut(T data);
        List<TVM> MapOutList(List<T> data);
        T MapIn(TVM data);
        List<T> MapInList(List<TVM> data);
        void MapDtoToTarget(TVM vm, T t);
    }

    
    public class ProductMapper: IEntityObjectMapper<Product, ProductVm>
    {
        public void MapDtoToTarget(ProductVm vm, Product t)
        {
            throw new NotImplementedException();
        }

        public Product MapIn(ProductVm data)
        {
            throw new NotImplementedException();
        }

        public List<Product> MapInList(List<ProductVm> data)
        {
            throw new NotImplementedException();
        }

        public ProductVm MapOut(Product data)
        {
            throw new NotImplementedException();
        }

        public List<ProductVm> MapOutList(List<Product> data)
        {
            throw new NotImplementedException();
        }
    }

    public class Product
    {

    }

    public class ProductVm
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

