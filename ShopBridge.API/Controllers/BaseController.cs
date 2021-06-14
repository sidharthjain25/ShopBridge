using DataLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase where TEntity : class, IBaseEntity
    {
        private IApplicationRepository<TEntity> _repository;

        public BaseController(IApplicationRepository<TEntity> repository)
        {
            _repository = repository;
        }

        // GET: api/Base
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }

        // GET: api/Base/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repository.Get(id));
        }

        // POST: api/Base
        [HttpPost]
        public IActionResult Post([FromBody] TEntity record)
        {
            return Ok(_repository.Create(record));
        }

        // PUT: api/Base/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TEntity record)
        {
            return Ok(_repository.Update(record));

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
