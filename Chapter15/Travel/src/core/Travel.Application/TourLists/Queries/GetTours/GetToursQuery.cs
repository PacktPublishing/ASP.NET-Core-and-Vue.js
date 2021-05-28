using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Travel.Application.Common.Interfaces;
using Travel.Application.Dtos.Tour;

namespace Travel.Application.TourLists.Queries.GetTours
{
    public class GetToursQuery : IRequest<ToursVm> { }

    public class GetToursQueryHandler : IRequestHandler<GetToursQuery, ToursVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;
        public GetToursQueryHandler(IApplicationDbContext context, IMapper mapper, IDistributedCache distributedCache)
        {
            _context = context;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        public async Task<ToursVm> Handle(GetToursQuery request, CancellationToken cancellationToken)
        {
            const string cacheKey = "GetTours";
            ToursVm tourLists; string serializedTourList;

            var redisTourLists = await _distributedCache.GetAsync(cacheKey, cancellationToken);

            if (redisTourLists == null)
            {
                tourLists = new ToursVm
                {
                    Lists = await _context.TourLists
                        .ProjectTo<TourListDto>(_mapper.ConfigurationProvider)
                        .OrderBy(t => t.City)
                        .ToListAsync(cancellationToken)
                };
                serializedTourList = JsonConvert.SerializeObject(tourLists);
                redisTourLists = Encoding.UTF8.GetBytes(serializedTourList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(1));
                await _distributedCache.SetAsync(cacheKey, redisTourLists, options, cancellationToken);

                return tourLists;
            }

            serializedTourList = Encoding.UTF8.GetString(redisTourLists);
            tourLists = JsonConvert.DeserializeObject<ToursVm>(serializedTourList);

            return tourLists;
        }
    }
}