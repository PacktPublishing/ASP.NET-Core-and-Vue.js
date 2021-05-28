using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourPackages.Commands.CreateTourPackage
{
  public class CreateTourPackageCommandValidator : AbstractValidator<CreateTourPackageCommand>
  {
    private readonly IApplicationDbContext _context;

    public CreateTourPackageCommandValidator(IApplicationDbContext context)
    {
      _context = context;

      RuleFor(v => v.Name)
        .NotEmpty().WithMessage("Name is required.")
        .MaximumLength(200).WithMessage("Name must not exceed 200 characters.")
        .MustAsync(BeUniqueName).WithMessage("The specified name already exists.");

      RuleFor(v => v.ListId)
        .NotEmpty().WithMessage("ListId is required");
    }

    private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
      return await _context.TourPackages
        .AllAsync(l => l.Name != name, cancellationToken);
    }
  }
}