using FluentValidation;
using RBA.Domain.Entities;

namespace RBA.Api.Validation;

public class ActionValidator : AbstractValidator<Domain.Entities.Action>
{
  public ActionValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required!");

    RuleFor(x => x.Application_Cd)
      .NotEmpty()
      .WithMessage("Application_Cd is required!")
      .MaximumLength(3)
      .WithMessage("Application_Cd is too long!");
  }
}

