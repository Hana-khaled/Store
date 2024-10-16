using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync();
            //var mappedBrands = brands.Select(b => new BrandTypeDetailsDto
            //{
            //    Id = b.Id,
            //    Name = b.Name,
            //    CreatedAt = b.CreatedAt
            //}).ToList();

            var mappedBrands = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(brands);

            return mappedBrands;
        }

        public async Task<IReadOnlyList<ProductDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Repository<Product, int>().GetAllAsync();
            //var mappedProducts = products.Select(p => new ProductDto
            //{
            //    Id = p.Id,
            //    Name = p.Name,
            //    Price = p.Price,
            //    ImageUrl = p.ImageUrl,
            //    BrandName = p.Brand.Name,
            //    TypeName = p.Type.Name,
            //    CreatedAt = p.CreatedAt

            //}).ToList();

            var mappedProducts = _mapper.Map<IReadOnlyList<ProductDto>>(products);

            return mappedProducts;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();
            //var mappedtypes = types.Select(t => new BrandTypeDetailsDto
            //{
            //    Id = t.Id,
            //    Name = t.Name,
            //    CreatedAt = t.CreatedAt
            //}).ToList();

            var mappedtypes = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(types);

            return mappedtypes;
        }

        public async Task<ProductDto> GetProductByIdAsync(int? id)
        {
            if (id is null)
                throw new Exception("Id is Null");

            var product = await _unitOfWork.Repository<Product, int>().GetByIdAsync(id.Value);

            if (product is null)
                throw new Exception("Product not Found");

            //var mappedProduct = new ProductDto
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Price = product.Price,
            //    ImageUrl = product.ImageUrl,
            //    BrandName = product.Brand.Name,
            //    TypeName = product.Type.Name,
            //    CreatedAt = product.CreatedAt
            //};

            var mappedProduct = _mapper.Map<ProductDto>(product);

            return mappedProduct;
        }
    }
}
