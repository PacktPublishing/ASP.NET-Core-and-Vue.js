using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourPackages.Commands.UpdateTourPackage
{
  public class UpdateTourPackageCommandValidator : AbstractValidator<UpdateTourPackageCommand>
  {
    private readonly IApplicationDbContext _context;

    public UpdateTourPackageCommandValidator(IApplicationDbContext context)
    {
      _context = context;

      RuleFor(v => v.Name)
        .NotEmpty().WithMessage("Name is required.")
        .MaximumLength(200).WithMessage("Name must not exceed 200 characters.")
        .MustAsync(BeUniqueName).WithMessage("The specified name already exists.");
    }

    public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
      return await _context.TourPackages
        .AllAsync(l => l.Name != name);
    }
  }
}