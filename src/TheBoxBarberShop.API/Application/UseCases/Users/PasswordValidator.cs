using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace TheBoxBarberShop.Application.UseCases.Users;

public class PasswordValidator<T> : PropertyValidator<T, string>
{
    public override string Name => "PasswordValidator";

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return "{ErrorMessage}";
    }
    public override bool IsValid(ValidationContext<T> context, string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            context.MessageFormatter.AppendArgument("ErrorMessage", "Sua senha deve ter pelo menos 6 caracteres");
            return false;
        }

        if (password.Length < 6)
        {
            context.MessageFormatter.AppendArgument("ErrorMessage", "Sua senha deve ter pelo menos 6 caracteres");
            return false;
        }

        return true;
    }
}
