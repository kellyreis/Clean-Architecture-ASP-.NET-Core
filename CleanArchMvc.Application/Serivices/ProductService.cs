using CleanArchMvc.Application.Interface;
using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CleanArchMvc.Application.Serivices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private IProductRepository _productRepository;
        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task Add(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<ProductDTO>(productDto);
            await _productRepository.Create(productEntity);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productEntity = await _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetCategories()
        {
            var productEntity = await _productRepository.GetProduct();
            return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
        }

        public async Task Remove(int? id)
        {
            var product = _productRepository.GetById(id).Result;
            await _productRepository.Remove(product);
        }

        public async Task Update(ProductDTO productDto)
        {
            var product = _mapper.Map<ProductDTO>(productDto);
            await _productRepository.Update(product);
        }
    }
}
