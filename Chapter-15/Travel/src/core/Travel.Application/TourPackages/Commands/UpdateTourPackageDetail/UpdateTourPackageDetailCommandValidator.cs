using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourPackages.Commands.UpdateTourPackageDetail
{
  public class UpdateTourPackageDetailCommandValidator : AbstractValidator<UpdateTourPackageDetailCommand>
  {
    private readonly IApplicationDbContext _context;

    public UpdateTourPackageDetailCommandValidator(IApplicationDbContext context)
    {
      _context = context;

      RuleFor(v => v.ListId)
        .NotEmpty().WithMessage("ListId is required");
      RuleFor(v => v.WhatToExpect)
        .NotEmpty().WithMessage("WhatToExpect is required");
      RuleFor(v => v.MapLocation)
        .NotEmpty().WithMessage("MapLocation is required");
      RuleFor(v => v.Price)
        .NotEmpty().WithMessage("Price is required");
      RuleFor(v => v.Duration)
        .NotEmpty().WithMessage("Duration is required");
      RuleFor(v => v.InstantConfirmation)
        .NotEmpty().WithMessage("InstantConfirmation is required");
      RuleFor(v => v.Currency)
        .NotEmpty().WithMessage("Currency is required");
    }

    public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
      return await _context.TourPackages
        .AllAsync(l => l.Name != name);
    }
  }
}