using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourLists.Commands.UpdateTourList
{
  public class UpdateTourListCommandValidator : AbstractValidator<UpdateTourListCommand>
  {
    private readonly IApplicationDbContext _context;

    public UpdateTourListCommandValidator(IApplicationDbContext context)
    {
      _context = context;

      RuleFor(v => v.City)
        .NotEmpty().WithMessage("City is required.")
        .MaximumLength(200).WithMessage("City must not exceed 90 characters.");

      RuleFor(v => v.Country)
        .NotEmpty().WithMessage("Country is required")
        .MaximumLength(200).WithMessage("Country must not exceed 60 characters.");

      RuleFor(v => v.About)
        .NotEmpty().WithMessage("About is required");
    }
  }
}