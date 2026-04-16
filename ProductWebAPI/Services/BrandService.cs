using Microsoft.EntityFrameworkCore;
using ProductWebAPI.Models;

namespace ProductWebAPI.Services
{
    public class BrandService : IBrandService
    {
        public readonly ProductDBContext productContext;

        public BrandService(ProductDBContext prdContext)
        {
            productContext = prdContext;
        }

        public async Task<List<Brand>> GetAllBrands()
        {
            return await productContext.Brands.ToListAsync();
        }

        public async Task<Brand?> GetBrandById(int brdId)
        {
            return await productContext.Brands
                .FirstOrDefaultAsync(b => b.BrandId == brdId);
        }

        public async Task<int> AddBrand(Brand brd)
        {
            await productContext.Brands.AddAsync(brd);
            await productContext.SaveChangesAsync();
            return brd.BrandId;
        }
    }
}