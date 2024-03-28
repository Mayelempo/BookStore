using FluentValidation;

namespace BookStore.Presentation.ValidationRules
{
    public static class CategoryValidationRules
    {
        public static IRuleBuilderOptions<T, string> CategoryNameValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var builder = ruleBuilder
                .NotNull()
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(25)
                .WithMessage("Invalid CategoryName");

            return builder;
        }
    }
}
