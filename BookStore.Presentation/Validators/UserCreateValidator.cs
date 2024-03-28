using BookStore.BusinessLogic.Dtos.Users;
using BookStore.Presentation.ValidationRules;
using FluentValidation;

namespace BookStore.Presentation.Validators
{
    public class UserCreateValidator: AbstractValidator<UserCreateDto>
    {
        public UserCreateValidator()
        { 
                RuleFor(x => x.Email)
                   .EmailValidation();
                RuleFor(x => x.Password)
                    .PasswordValidation();
                RuleFor(x => x.phoneNumber)
                    .PhoneNumberValidation();
                RuleFor(x => x.Name)
                    .NameValidation();
                RuleFor(x => x.LastName)
                    .NameValidation();
        }

    }
}
