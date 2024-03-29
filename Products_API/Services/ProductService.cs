﻿using Microsoft.AspNetCore.Http.HttpResults;
using Products_API.DTOs;
using Products_API.Model;
using Products_API.Repository;

namespace Products_API.Services
{
    public class ProductService : ICommonService<ProductDto, ProductEditDto>
    {
        private IRepository<Product> _repository;
        public ProductService([FromKeyedServices("productRepository")]IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Add(ProductEditDto productDto)
        {
            try
            {
                Product product = new Product
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    BrandId = productDto.BrandId
                };
                await _repository.Add(product);
                await _repository.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductDto>> Get()
        {
            var products = await _repository.Get();
            return products.Select(p => new ProductDto
            {
                Name = p.Name,
                Price = p.Price,
                BrandDesc = p.Brand.Name
            });
        }

        public async Task<ProductDto> GetById(int id)
        {
            Product product = await _repository.GetById(id);
            return new ProductDto
            {
                Name = product.Name,
                Price = product.Price,
                BrandDesc = product.Brand.Name
            };
        }

        public async Task<bool> Update(int id, ProductEditDto productDto)
        {
            Product product = await _repository.GetById(id);
            if (product != null)
            {
                product.Name = productDto.Name;
                product.Price = productDto.Price;
                product.BrandId = productDto.BrandId;
                _repository.Update(product);
                await _repository.Save();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            Product product = await _repository.GetById(id);
            if (product != null)
            {
                _repository.Delete(product);
                await _repository.Save();
                return true;
            }
            return false;
        }
    }
}
