using FluentValidation;

namespace BookStore.Presentation.ValidationRules
{
    public static class BookValidationRules
    {

        public static IRuleBuilderOptions<T, string> BookNameValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var builder = ruleBuilder
                .NotNull()
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(25)
                .WithMessage("Invalid bookName");

            return builder;
        }

        public static IRuleBuilderOptions<T, string> BookDescriptionValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var builder = ruleBuilder
                .NotNull() 
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(100)
                .WithMessage("Invalid bookDescription");

            return builder;
        }
    }
}
