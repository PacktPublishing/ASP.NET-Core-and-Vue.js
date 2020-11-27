using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Travel.Application.Common.Interfaces;
using Travel.Application.Dtos.Tour;

namespace Travel.Application.TourPackages.Queries
{
    public class GetTourIPackagesQuery : IRequest<TourPackageDto>
    {
        public int ListId { get; set; }
    }

    public class GetTourIPackagesQueryHandler : IRequestHandler<GetTourIPackagesQuery, TourPackageDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTourIPackagesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public  Task<TourPackageDto> Handle(GetTourIPackagesQuery request, CancellationToken cancellationToken)
        {
            var tourPackages =  _context.TourPackages
                .Where(t => t.ListId == request.ListId)
                .OrderBy(t => t.Name)
                .ProjectTo<TourPackageDto>(_mapper.ConfigurationProvider);
            return tourPackages;
        }
    }
}