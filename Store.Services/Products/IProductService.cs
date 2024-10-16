using Store.Data.Entities;
using Store.Services.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Products
{
    public interface IProductService
    {
        Task<ProductDto> GetProductByIdAsync(int? id);
        Task<IReadOnlyList<ProductDto>> GetAllProductsAsync();
        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync();
        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync();

    }
}
