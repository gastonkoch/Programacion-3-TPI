using Application.Models;
using Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
        ProductDto GetProductById(int id);
        ProductDto CreateProduct(ProductCreateRequest product);
        ICollection<ProductDto> GetAllProducts();
        void UpdateProduct(int id, ProductCreateRequest productDto);
        void DeleteProduct(int id);
    }
}
