using BookStore.BusinessLogic.Dtos.Books;
using BookStore.BusinessLogic.Dtos.Categories;
using BookStore.Presentation.ValidationRules;
using FluentValidation;

namespace BookStore.Presentation.Validators
{
    public class CategoryValidation:AbstractValidator<CategoryDto>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name)
               .CategoryNameValidation();
            
        }
    }
}
