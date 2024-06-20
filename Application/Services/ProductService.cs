using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ICollection<ProductDto> GetAllProducts()
        {
            var products = ProductDto.ToList(_productRepository.ListAsync().Result ?? throw new Exception("No se encontraron usuarios"));
            return products;
        }

        public ProductDto GetProductById(int id)
        {
            ProductDto productDto = ProductDto.ToDto(_productRepository.GetByIdAsync(id).Result ?? throw new Exception("No se encontro el Producto"));
            return productDto;
        }

        public ProductDto CreateProduct(ProductCreateRequest dto)
        {
            return ProductDto.ToDto(_productRepository.AddAsync(ProductCreateRequest.ToEntity(dto)).Result);
        }

        public void UpdateProduct(int id, ProductCreateRequest productDto)
        {
            _productRepository.UpdateAsync(ProductCreateRequest.ToEntity(productDto));
        }

        public void DeleteProduct(int id)
        {
            var productDto = _productRepository.GetByIdAsync(id).Result ?? throw new Exception("No se encontro el usuario");
            _productRepository.DeleteAsync(productDto);
        }
    }
}
