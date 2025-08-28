using FluentValidation;
using Todo.Domain.Models;

namespace Todo.Application.Validators.ItemValidators;

public class ItemValidator : AbstractValidator<Item>
{
  public ItemValidator()
  {
    RuleFor(x => x.Title)
      .NotEmpty()
      .MinimumLength(5)
      .MaximumLength(100);
    RuleFor(x => x.User)
      .NotEmpty();
    RuleFor(x => x.UserId)
      .NotEmpty();
    RuleFor(x => x.CompletedDate)
      .NotEmpty();
  } 
}