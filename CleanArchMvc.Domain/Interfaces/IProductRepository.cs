﻿using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProduct();
        Task<Product> GetById(int? id);
        Task<Product> GetByIdCategoria(int? id);
        Task<Product> Create(Product category);
        Task<Product> Update(Product category);
        Task<Product> Remove(Product category);
    }
}
