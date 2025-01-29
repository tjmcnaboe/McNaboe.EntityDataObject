using Microsoft.EntityFrameworkCore;

namespace McNaboe.EntityDataObject.Server
{
    public partial class MappedEntityService<TVM, DbContextType, TKey, T> : IEntityObjectService<TVM, TKey> where TVM : class where DbContextType : DbContext where T : class//: IEntityService
    {
        IDbContextFactory<DbContextType> _dbFactory;
        private IEntityObjectMapper<T, TVM> _mapper;

        public MappedEntityService(IDbContextFactory<DbContextType> factory, IEntityObjectMapper<T,TVM> mapper)
        {
            _dbFactory = factory;
            _mapper = mapper;
        }
        public DbContextType Context { get; set; }
        public virtual async Task<TVM> Get(TKey id)
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<T>();
            var source = await set.FindAsync(id);
            return MapOutput(source);
        }

        public virtual async Task<List<TVM>> GetAll()
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<T>();
            var source = set.ToList();
            return MapOutput(source);
        }
        public virtual async Task<IQueryable<TVM>> GetAllAsQueryable()
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<T>();
            var source = set.ToList();
            return MapOutput(source).AsQueryable();
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


        public virtual async Task<TVM> Update(TVM entityToUpdate)
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<T>();
            var origin = set.Find(GetKeyFromVm(entityToUpdate));
            UpdateFromInput(entityToUpdate, origin);
            await db.SaveChangesAsync();
            return entityToUpdate;

        }

        public virtual async Task<TVM> Update(TVM entityToUpdate, TKey id)
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<T>();
            var origin = set.Find(id);
            UpdateFromInput(entityToUpdate, origin);
            await db.SaveChangesAsync();
            return entityToUpdate;
        }


        public virtual async Task<TVM> Insert(TVM entity)
        {
            using var db = _dbFactory.CreateDbContext();
            var set = db.Set<T>();
            var sourceEntity = MapInput(entity);
            set.Add(sourceEntity);
            await db.SaveChangesAsync();
            return entity;
        }


        public virtual TVM MapOutput(T input)
        {
            return _mapper.MapOut(input);
        }


        public virtual List<TVM> MapOutput(List<T> input)
        {
            return _mapper.MapOutList(input);
        }

        public virtual T MapInput(TVM input)
        {
            return _mapper.MapIn(input);
        }

        public virtual List<T> MapInput(List<TVM> input)
        {
            return _mapper.MapInList(input);
        }
        public virtual TKey GetKeyFromVm(TVM input)
        {
            throw new NotImplementedException();
        }
        public virtual T UpdateFromInput(TVM vmInput, T source)
        {
            _mapper.MapDtoToTarget(vmInput, source);
            return source;
        }

        public virtual T CreateFromVm(TVM vmInput)
        {
            return _mapper.MapIn(vmInput);
        }

    }
}
