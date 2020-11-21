using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
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
            const string cacheKey = "tourList";
            ToursVm tourList;
            string serializedCustomerList;

            var redisTourList = await _distributedCache.GetAsync(cacheKey, cancellationToken);

            if (redisTourList == null)
            {
                tourList = new ToursVm
                {
                    Lists = await _context.TourLists
                        .ProjectTo<TourListDto>(_mapper.ConfigurationProvider)
                        .OrderBy(t => t.City)
                        .ToListAsync(cancellationToken)
                };
                serializedCustomerList = JsonConvert.SerializeObject(tourList);
                redisTourList = Encoding.UTF8.GetBytes(serializedCustomerList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await _distributedCache.SetAsync(cacheKey, redisTourList, options, cancellationToken);
                Console.WriteLine(tourList);
                return tourList;
            }
            
            serializedCustomerList = Encoding.UTF8.GetString(redisTourList);
            tourList = JsonConvert.DeserializeObject<ToursVm>(serializedCustomerList);
            Console.WriteLine(tourList);
            return tourList;
        }
    }
}