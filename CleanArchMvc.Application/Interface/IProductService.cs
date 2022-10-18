using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetCategories();
        Task<ProductDTO> GetById(int? id);
        Task Add(ProductDTO productDto);
        Task Update(ProductDTO productDto);
        Task Remove(int? id);
    }
}
