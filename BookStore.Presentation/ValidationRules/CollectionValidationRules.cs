using FluentValidation;

namespace BookStore.Presentation.ValidationRules
{
    public static class CollectionValidationRules
    {

        public static IRuleBuilderOptions<T, string> CollectionNameValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var builder = ruleBuilder
                .NotNull()
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(25)
                .WithMessage("Invalid ColletionName");

            return builder;
        }
        public static IRuleBuilderOptions<T, string> CollectionDescriptionValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var builder = ruleBuilder
                .NotNull()
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(100)
                .WithMessage("Invalid collectionDescription");

            return builder;
        }

    }
}
