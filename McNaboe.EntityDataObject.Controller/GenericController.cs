using Microsoft.AspNetCore.Mvc;

namespace McNaboe.EntityDataObject.Controller
{
    public abstract class GenericController<T, TKey> : ControllerBase where T : class
    {
        private IEntityObjectService<T, TKey> _service;

        public GenericController(IEntityObjectService<T, TKey> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(TKey id)
        {
            return await _service.Get(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Update(T item)
        {
            await _service.Update(item);
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<T>> Create(T item)
        {
            return await _service.Insert(item);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(TKey id)
        {
            await _service.Delete(id);
            return true;
        }

    }



    public abstract class GenericQueryableController<T, TKey> : ControllerBase where T : class
    {
        private IEntityObjectService<T, TKey> _service;

        public GenericQueryableController(IEntityObjectService<T, TKey> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task <IQueryable<T>> GetAll()
        {
            return await _service.GetAllAsQueryable();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(TKey id)
        {
            return await _service.Get(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Update(T item)
        {
            await _service.Update(item);
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<T>> Create(T item)
        {
            return await _service.Insert(item);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(TKey id)
        {
            await _service.Delete(id);
            return true;
        }

    }
}
