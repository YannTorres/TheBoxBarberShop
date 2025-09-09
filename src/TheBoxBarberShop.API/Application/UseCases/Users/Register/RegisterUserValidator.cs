using FluentValidation;
using Microsoft.AspNetCore.Identity;
using TheBoxBarberShop.Communication.Request.Users;

namespace TheBoxBarberShop.Application.UseCases.Users.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisteredUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .MaximumLength(200).WithMessage("Nome não pode exceder 200 caracteres.");
        RuleFor(x => x.NickName)
            .NotEmpty().WithMessage("Apelido é Obrigatório.")
            .MaximumLength(50).WithMessage("Apelido não pode exceder 50 caracteres.");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email é Obrigatório.")
            .EmailAddress().When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
            .WithMessage("Email no formato inválido.")
            .MaximumLength(200).WithMessage("Email não pode exceder 200 caracteres.");

        RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestRegisteredUserJson>());
    }
}
