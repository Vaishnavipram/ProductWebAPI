using ProductWebAPI.Models;

namespace ProductWebAPI.Services
{
    public interface IBrandService
    {
        Task<int> AddBrand(Brand brd);

        Task<List<Brand>> GetAllBrands();   // ✅ remove ?

        Task<Brand?> GetBrandById(int brdId); // ✅ FIXED
    }
}