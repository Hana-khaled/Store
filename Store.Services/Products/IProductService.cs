using Store.Data.Entities;
using Store.Repository.Sepcification.ProductSpecs;
using Store.Services.Helper;
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
        Task<PaginatedResultDto<ProductDto>> GetAllProductsAsync(ProductSpecification specs);
        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync();
        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync();

    }
}
