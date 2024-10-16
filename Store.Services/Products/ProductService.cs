using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync();
            var mappedBrands = brands.Select(b => new BrandTypeDetailsDto
            {
                Id = b.Id,
                Name = b.Name,
                CreatedAt = b.CreatedAt
            }).ToList();

            return mappedBrands;
        }

        public async Task<IReadOnlyList<ProductDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Repository<Product, int>().GetAllAsync();
            var mappedProducts = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                BrandName = p.Brand.Name,
                TypeName = p.Type.Name,
                CreatedAt = p.CreatedAt

            }).ToList();

            return mappedProducts;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();
            var mappedtypes = types.Select(t => new BrandTypeDetailsDto
            {
                Id = t.Id,
                Name = t.Name,
                CreatedAt = t.CreatedAt
            }).ToList();

            return mappedtypes;
        }

        public async Task<ProductDto> GetProductByIdAsync(int? id)
        {
            var product = await _unitOfWork.Repository<Product, int>().GetByIdAsync(id.Value);
            var mappedProduct = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                BrandName = product.Brand.Name,
                TypeName = product.Type.Name,
                CreatedAt = product.CreatedAt
            };

            return mappedProduct;
        }
    }
}
