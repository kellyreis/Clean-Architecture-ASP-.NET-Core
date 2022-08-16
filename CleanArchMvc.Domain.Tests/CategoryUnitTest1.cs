using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObejectValidState()
        {
            Action action = () => new Category("Category Name",1);
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();

        }

        [Fact]
        public void CreateCategory_negativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category("Category Name", -1);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid id value.");

        }

      
    }
}