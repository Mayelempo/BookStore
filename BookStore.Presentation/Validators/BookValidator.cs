using BookStore.BusinessLogic.Dtos.Books;
using BookStore.BusinessLogic.Dtos.Users;
using BookStore.DataAccess.Repositories;
using BookStore.Presentation.Profiles;
using BookStore.Presentation.ValidationRules;
using FluentValidation;

namespace BookStore.Presentation.Validators
{
    public class BookValidator : AbstractValidator<BookDto>
    {
            public BookValidator()
            {
                RuleFor(x => x.Name)
                   .BookNameValidation();
                RuleFor(x => x.Description)
                    .BookDescriptionValidation();
            }

        
    }
}
