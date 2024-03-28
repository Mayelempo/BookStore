using BookStore.BusinessLogic.Dtos.Collections;
using BookStore.Presentation.ValidationRules;
using FluentValidation;

namespace BookStore.Presentation.Validators
{
    public class CollectionValidation: AbstractValidator<CollectionDto>
    {
        public CollectionValidation()
        {
            RuleFor(x => x.Name)
               .CollectionNameValidation();
            RuleFor(x => x.Description)
                .CollectionDescriptionValidation();
        }

    }
}
