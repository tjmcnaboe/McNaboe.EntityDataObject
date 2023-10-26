using EntityDataObjectDemo.EntityObjectServices;
using EntityDataObjectDemo.Model;
using McNaboe.EntityDataObject.Controller;
using Microsoft.AspNetCore.Mvc;

namespace EntityDataObjectDemo.EntityObjectControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductServiceController : GenericController<Product, int>
    {
        public ProductServiceController(IProductEntityService service) : base(service)
        {
        }
    }
}
