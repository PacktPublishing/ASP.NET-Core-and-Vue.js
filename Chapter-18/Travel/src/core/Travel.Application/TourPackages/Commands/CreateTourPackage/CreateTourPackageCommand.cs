using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Travel.Application.Common.Interfaces;
using Travel.Domain.Entities;
using Travel.Domain.Enums;

namespace Travel.Application.TourPackages.Commands.CreateTourPackage
{
  public class CreateTourPackageCommand : IRequest<int>
  {
    public int ListId { get; set; }
    public string Name { get; set; }
    public string WhatToExpect { get; set; }
    public string MapLocation { get; set; }
    public float Price { get; set; }
    public int Duration { get; set; }
    public bool InstantConfirmation { get; set; }
    public Currency Currency { get; set; }
  }

  public class CreateTourPackageCommandHandler : IRequestHandler<CreateTourPackageCommand, int>
  {
    private readonly IApplicationDbContext _context;

    public CreateTourPackageCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<int> Handle(CreateTourPackageCommand request, CancellationToken cancellationToken)
    {
      var entity = new TourPackage
      {
        ListId = request.ListId,
        Name = request.Name,
        WhatToExpect = request.WhatToExpect,
        MapLocation = request.MapLocation,
        Price = request.Price,
        Duration = request.Duration,
        InstantConfirmation = request.InstantConfirmation,
        Currency = request.Currency
      };
      _context.TourPackages.Add(entity);
      await _context.SaveChangesAsync(cancellationToken);

      return entity.Id;
    }
  }
}