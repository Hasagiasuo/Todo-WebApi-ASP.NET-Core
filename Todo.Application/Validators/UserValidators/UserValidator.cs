using FluentValidation;

namespace Todo.Application.Validators.UserValidators;

public class UserValidator : AbstractValidator<Domain.Models.User>
{
  public UserValidator()
  {
    RuleFor(x => x.Username)
      .NotEmpty()
      .MinimumLength(4)
      .MaximumLength(14);
    RuleFor(x => x.Token)
      .NotEmpty()
      .MinimumLength(49)
      .MaximumLength(50);
  } 
}