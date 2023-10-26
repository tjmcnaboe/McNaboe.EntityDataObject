using EntityDataObjectDemo.Client.Dtos;
using EntityDataObjectDemo.Model;
using McNaboe.EntityDataObject;
using McNaboe.EntityDataObject.Server;
using Microsoft.EntityFrameworkCore;
using Riok.Mapperly.Abstractions;

namespace EntityDataObjectDemo.EntityObjectServices
{
    public class ProductEntityService<db> : EntityService<Product, db, int>, IEntityObjectService<Product, int>, IProductEntityService where db : DbContext
    {
        public ProductEntityService(IDbContextFactory<db> factory) : base(factory)
        {
        }

    }

    public interface IProductEntityService : IIntKeyObjectService<Product>
    {

    }



}
