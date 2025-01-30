using EntityDataObjectDemo.Client.Dtos;
using EntityDataObjectDemo.Client.EntityObjectServices;
using EntityDataObjectDemo.Model;
using McNaboe.EntityDataObject;
using McNaboe.EntityDataObject.Server;
using Microsoft.EntityFrameworkCore;
using Riok.Mapperly.Abstractions;

namespace EntityDataObjectDemo.EntityObjectServices
{
    public class ProductDtoEntityService<db> : MappedEntityService<ProductDto, db, int, Product>, IEntityObjectService<ProductDto, int>, IProductDtoEntityService where db : DbContext
    {
        public ProductDtoEntityService(IDbContextFactory<db> factory) : base(factory)
        {
        }
        public override List<ProductDto> MapOutput(List<Product> input)
        {
            return new ProductVmMapper().MapOutList(input);
        }
        public override ProductDto MapOutput(Product input)
        {
            return new ProductVmMapper().MapOut(input);
        }

        public override Product MapInput(ProductDto input)
        {
            return new ProductVmMapper().MapIn(input);
        }
        public override Product UpdateFromInput(ProductDto vmInput, Product product)
        {
            //var product = this.Context.Set<Product>().Find(vmInput.Id);

            new ProductVmMapper().ProductDtoToProduct(vmInput, product);
            return product;
        }
        public override Product CreateFromVm(ProductDto vmInput)
        {
            var product = new Product();

            new ProductVmMapper().ProductDtoToProduct(vmInput, product);
            return product;
        }
        public override int GetKeyFromVm(ProductDto input)
        {
            return input.Id;
        }
    }

    [Mapper]
    public partial class ProductVmMapper
    {
        public partial ProductDto MapOut(Product data);
        public partial List<ProductDto> MapOutList(List<Product> data);
        public partial Product MapIn(ProductDto data);
        public partial List<Product> MapInList(List<ProductDto> data);
        public partial void ProductDtoToProduct(ProductDto vm, Product product);
    }
    [Mapper]
    public partial class  EntityDataObjectMapper<T,TVM> where T :class
    {
        public partial TVM MapOut(T model);
        List<ProductDto> MapOutList(List<Product> data);
        public partial Product MapIn(ProductDto data);
        public partial List<Product> MapInList(List<ProductDto> data);
        public partial void ProductDtoToProduct(ProductDto vm, Product product);
    }
    //[Mapper]
    //public partial class GenericVmMapper<T,TVM> where T : class where TVM : class
    //{
    //    public partial TVM MapOut(T data);
    //    public partial List<ProductDto> MapOutList(List<Product> data);
    //    public partial Product MapIn(ProductDto data);
    //    public partial List<Product> MapInList(List<ProductDto> data);
    //    public partial void ProductDtoToProduct(ProductDto vm, Product product);
    //}
}
