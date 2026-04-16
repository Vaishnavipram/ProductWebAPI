using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.Models;
using ProductWebAPI.Services;

namespace ProductWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await brandService.GetAllBrands(); // ✅ will work now
            return Ok(brands);
        }

        [HttpGet]
        public async Task<IActionResult> GetBrandById(int brdId)
        {
            var brand = await brandService.GetBrandById(brdId);

            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand(Brand brand)
        {
            int result = await brandService.AddBrand(brand);

            if (result > 0)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}