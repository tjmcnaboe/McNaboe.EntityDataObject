using EntityDataObjectDemo.Client.Dtos;
using McNaboe.EntityDataObject;
using McNaboe.EntityDataObject.Client;

namespace EntityDataObjectDemo.Client.EntityObjectServices
{
    public interface IProductDtoHttpService : IHttpObjectService<ProductDto, int>
    {

    }

    public class ProductDtoHttpApiService : HttpApiServiceWrapper<ProductDto, int>, IProductDtoEntityService
    {

        public ProductDtoHttpApiService(IProductDtoHttpService api) : base(api)
        {
            _api = api;
        }

    }

    public interface IProductDtoEntityService : IIntKeyObjectService<ProductDto>
    {

    }
}
