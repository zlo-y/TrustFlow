using FluentValidation;
using Banking.Application.Features.Accounts.Commands.CreateAccount;

namespace Banking.CreateAccountCommandValidator;

public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
     public CreateAccountCommandValidator()
    {
        RuleFor(x => x.Owner)
            .NotEmpty()
            .MaximumLength(200);
        RuleFor(x => x.InitialAmount) 
            .GreaterThanOrEqualTo(0);
        RuleFor(x => x.Currency)
            .NotEmpty()
            .Length(3);   
    }
}