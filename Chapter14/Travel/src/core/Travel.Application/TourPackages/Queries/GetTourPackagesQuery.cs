using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Travel.Application.Common.Interfaces;
using Travel.Application.Dtos.Tour;

namespace Travel.Application.TourPackages.Queries
{
    public class GetTourPackagesQuery : IRequest<List<TourPackageDto>>
    {
        public int ListId { get; set; }
    }

    public class GetTourPackagesQueryHandler : IRequestHandler<GetTourPackagesQuery, List<TourPackageDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTourPackagesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<TourPackageDto>> Handle(GetTourPackagesQuery request, CancellationToken cancellationToken)
        {
            var tourPackages = _context.TourPackages
                .Where(tp => tp.ListId == request.ListId)
                .OrderBy(tp => tp.Name)
                .ProjectTo<TourPackageDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            
            return tourPackages;
        }
    }
}