using Microsoft.EntityFrameworkCore;

namespace McNaboe.EntityDataObject.Server
{
    public partial class EntityService<T, DbContextType, TKey> : IEntityObjectService<T, TKey> where T : class where DbContextType : DbContext//: IEntityService
    {
        public IDbContextFactory<DbContextType> _dbFactory;
        public EntityService(IDbContextFactory<DbContextType> factory)
        {
            _dbFactory = factory;
        }
        public DbContextType Context { get; set; }
        public virtual async Task<T> Get(TKey id)
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<T>();
            return await set.FindAsync(id);
        }

        public virtual async Task<List<T>> GetAll()
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<T>();
            return set.ToList();
        }



        public virtual async Task<T> Update(T entityToUpdate)
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<T>();
            set.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return entityToUpdate;
        }

        public virtual async Task<T> Insert(T entity)
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<T>();
            set.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(TKey Id)
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<T>();
            var delete = set.Find(Id);
            set.Remove(delete);
            await db.SaveChangesAsync();
            return true;
        }

        public virtual async Task<IQueryable<T>> GetAllAsQueryable()
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<T>();
            return set.ToList().AsQueryable();
        }
    }

}
