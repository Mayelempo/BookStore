using BookStore.BusinessLogic.Dtos.Users;
using BookStore.Presentation.ValidationRules;
using FluentValidation;

namespace BookStore.Presentation.Validators
{
    public class UserReadValidator: AbstractValidator<UserReadDto>
    {
        public UserReadValidator()
        {

            RuleFor(x => x.Email)
               .EmailValidation();
            RuleFor(x => x.phoneNumber)
                .PhoneNumberValidation();
            RuleFor(x => x.Name)
                .NameValidation();
            RuleFor(x => x.LastName)
                .NameValidation();
        }
    }
}
