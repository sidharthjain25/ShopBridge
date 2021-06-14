using DataLayer.Entities;
using DataLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : BaseController<Inventory>
    {
        public InventoryController(IApplicationRepository<Inventory> repository) : base(repository)
        {
        }
    }
}
