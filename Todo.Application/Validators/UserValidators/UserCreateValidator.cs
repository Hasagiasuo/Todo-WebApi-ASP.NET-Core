using FluentValidation;

namespace Todo.Application.Validators.UserValidators;

public class UserCreateValidator : AbstractValidator<DTO.UserCreate>
{
  public UserCreateValidator()
  {
    RuleFor(x => x.Username)
      .NotEmpty()
      .MinimumLength(4)
      .MaximumLength(50);
  } 
}