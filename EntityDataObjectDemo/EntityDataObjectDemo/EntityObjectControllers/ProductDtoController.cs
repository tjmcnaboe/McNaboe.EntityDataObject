using EntityDataObjectDemo.Client.Dtos;
using EntityDataObjectDemo.Client.EntityObjectServices;
using McNaboe.EntityDataObject.Controller;
using Microsoft.AspNetCore.Mvc;

namespace EntityDataObjectDemo.EntityObjectControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDtoController : GenericController<ProductDto, int>
    {
        public ProductDtoController(IProductDtoEntityService service) : base(service)
        {
        }

    }
}
