using FluentValidation;

namespace BookStore.Presentation.ValidationRules
{
    public static class UserValidationRules
    {
        public static IRuleBuilderOptions<T, string> EmailValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var builder = ruleBuilder
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Received invalid email");
            return builder;
        }

        public static IRuleBuilderOptions<T, string> NameValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var builder = ruleBuilder
                .NotEmpty()
                .NotNull()
                .MinimumLength(4)
                .WithMessage("Invalid Name");
            return builder;
        }

        public static IRuleBuilderOptions<T, string> PhoneNumberValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var builder = ruleBuilder
                .NotEmpty()
                .MinimumLength(9)
                .Matches(@"\+(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|
                    2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|
                    4[987654310]|3[9643210]|2[70]|7|1)\d{1,14}$") 
                .WithMessage("Invalid phone Number");
            return builder;
        }

        public static IRuleBuilderOptions<T, string> PasswordValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var builder = ruleBuilder
                .NotEmpty()
                .MinimumLength(15);
            return builder;
        }

    }
}
