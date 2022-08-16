using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
       
        public string Name { get; private set; }
        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(string name, int id)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value.");
            ValidateDomain(name);
            Id = id;
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        public void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name.too shor 3 charecteres");

            Name = name;

        }
    }
}
