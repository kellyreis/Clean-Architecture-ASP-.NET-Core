using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;
namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
     
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        private void ValidateDomain(string name, string description, decimal price, int stock, string img)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name.too shor 3 charecteres");
            DomainExceptionValidation.When(description.Length < 5, "Invalid name.too shor 3 charecteres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. description is required");
            DomainExceptionValidation.When(stock < 0, "Invalid stock value.");
            DomainExceptionValidation.When(price < 0, "Invalid stock value.");
            DomainExceptionValidation.When(img?.Length < 250, "Invalid img name, too long, maximum 250 chacacters");
        }
        public Product(string name, string description, decimal price, int stock, string img)
        {
            ValidateDomain(name, description,price,stock,img);

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = img;

        }

        public Product(int id,string name, string description, decimal price, int stock, string img)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value.");
            ValidateDomain(name, description, price, stock, img);
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = img;

        }

        public void Update(string name, string description, decimal price, int stock, string img, int categoryId)
        {
            DomainExceptionValidation.When(categoryId < 0, "Invalid categoryId value.");
            ValidateDomain(name, description, price, stock, img);

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = img;
            IdCategory = categoryId;

        }



        public int IdCategory { get; set; }

        public Category Category { get; set; }
    }
}
