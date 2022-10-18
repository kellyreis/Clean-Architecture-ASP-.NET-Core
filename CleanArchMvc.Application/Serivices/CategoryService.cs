using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interface;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Serivices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task Add(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<CategoryDTO>(categoryDto);
            await _categoryRepository.Create(category);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var categoryEntity = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task Remove(int? id)
        {
            var category = _categoryRepository.GetById(id).Result;
            await _categoryRepository.Remove(category);
        }

        public async Task Update(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<CategoryDTO>(categoryDto);
            await _categoryRepository.Update(category);
        }
    }
}
