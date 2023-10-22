using Microsoft.EntityFrameworkCore;

namespace McNaboe.EntityDataObject.Server
{
    public partial class MappedEntityService<T, DbContextType, TKey, TSource> : IEntityObjectService<T, TKey> where T : class where DbContextType : DbContext where TSource : class//: IEntityService
    {
        IDbContextFactory<DbContextType> _dbFactory;
        public MappedEntityService(IDbContextFactory<DbContextType> factory)
        {
            _dbFactory = factory;
        }
        public DbContextType Context { get; set; }
        public virtual async Task<T> Get(TKey id)
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<TSource>();
            var source = await set.FindAsync(id);
            return MapOutput(source);
        }

        public virtual async Task<List<T>> GetAll()
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<TSource>();
            var source = set.ToList();
            return MapOutput(source);
        }

        public async Task<bool> Delete(TKey Id)
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<TSource>();
            var delete = set.Find(Id);
            set.Remove(delete);
            await db.SaveChangesAsync();
            return true;
        }


        public virtual async Task<T> Update(T entityToUpdate)
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<TSource>();
            var origin = set.Find(GetKeyFromVm(entityToUpdate));
            UpdateFromInput(entityToUpdate, origin);
            await db.SaveChangesAsync();
            return entityToUpdate;

        }

        public virtual async Task<T> Update(T entityToUpdate, TKey id)
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<TSource>();
            var origin = set.Find(id);
            UpdateFromInput(entityToUpdate, origin);
            await db.SaveChangesAsync();
            return entityToUpdate;
        }


        public virtual async Task<T> Insert(T entity)
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<TSource>();
            var sourceEntity = MapInput(entity);
            set.Add(sourceEntity);
            await db.SaveChangesAsync();
            return entity;
        }


        public virtual T MapOutput(TSource input)
        {
            throw new NotImplementedException();
        }


        public virtual List<T> MapOutput(List<TSource> input)
        {
            throw new NotImplementedException();
        }

        public virtual TSource MapInput(T input)
        {
            throw new NotImplementedException();
        }

        public virtual List<TSource> MapInput(List<T> input)
        {
            throw new NotImplementedException();
        }
        public virtual TKey GetKeyFromVm(T input)
        {
            throw new NotImplementedException();
        }
        public virtual TSource UpdateFromInput(T vmInput, TSource source)
        {
            throw new NotImplementedException();
        }

        public virtual TSource CreateFromVm(T vmInput)
        {
            throw new NotImplementedException();
        }

    }
}
