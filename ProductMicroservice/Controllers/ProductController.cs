using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ProductMicroservice.DataAccess.Repositories;
using ProductMicroservice.Entities;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            using (var data = new MongoRepository<ProductModel>())
            {
                var model = data.GetAll().ToList();
                return Ok(model);
            }
        }
        [HttpGet(nameof(Get))]
        public IActionResult Get(ProductModel model)
        {
            using (var data = new MongoRepository<ProductModel>())
            {
                var repo = data.Get(x => x.ProductId.Equals(model.ProductId));
                if (repo == null) return NotFound();
                return Ok(repo);

            }
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add(ProductModel model)
        {
            using (var data = new MongoRepository<ProductModel>())
            {
                try
                {
                    if (model == null)
                        return BadRequest();
                    data.Add(model);
                    return Ok(model);

                }
                catch (Exception)
                {

                    return StatusCode(500);
                }
            }
        }
        [HttpPut(nameof(Update))]
        public IActionResult Update(ProductModel model)
        {
            using (var data = new MongoRepository<ProductModel>())
            {
                try
                {
                    if (model == null)
                        return BadRequest();
                    data.Update(model);
                    return Ok(model);

                }
                catch (Exception)
                {

                    return StatusCode(500);
                }
            }
        }
        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(ProductModel model)
        {
            using (var data = new MongoRepository<ProductModel>())
            {
                try
                {
                    if (model == null)
                        return BadRequest();
                    data.Delete(x => x.Equals(model.ProductId));
                    return Ok(model);
                }
                catch (Exception)
                {

                    return StatusCode(500);
                }
            }
        }
    }
}
