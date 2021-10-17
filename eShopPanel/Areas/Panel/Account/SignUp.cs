using eShopPanel.Areas.Panel.Account.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using GenerateMediator;

namespace eShopPanel.Areas.Panel.Account
{
    [GenerateMediator]
    public static partial class SignUp
    {
        public sealed partial record Command(
            string Email,
            string Password,
            string ConfirmPassword
        )
        {
            public static void AddValidation(AbstractValidator<Command> v)
            {
                v.RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("Please enter email.")
                    .EmailAddress().WithMessage("Invalid email");

                v.RuleFor(x => x.Password)
                    .NotEmpty().WithMessage("Please enter password.");

                v.RuleFor(x => x.ConfirmPassword)
                    .NotEmpty().WithMessage("Please confirm password.")
                    .Equal(q => q.Password).WithMessage("Passwords are not equal.");
            }
        }

        public sealed record CommandResult(
           IdentityResult IdentityResult
        );

        public static async Task<CommandResult> CommandHandler(
            Command command,
            UserManager<ApplicationUser> userManager
        )
        {
            var user = new ApplicationUser
            {
                UserName = command.Email,
                Email = command.Email
            };

            var result = await userManager.CreateAsync(user, command.Password);

            return new(result);
        }
    }
}
