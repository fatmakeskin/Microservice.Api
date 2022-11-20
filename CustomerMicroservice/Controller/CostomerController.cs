using CustomerMicroservice.Data.Entities;
using CustomerMicroservice.DataAccess.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerMicroservice.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostomerController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(CustomerModel model)
        {
            using (var uow = new UnitofWork<CustomerModel>())
            {
                var data=uow.GetRepository<CustomerModel>().Get(x=>x.Id.Equals(model.Id));
                return Ok(data);
            }

        }
    }
}
