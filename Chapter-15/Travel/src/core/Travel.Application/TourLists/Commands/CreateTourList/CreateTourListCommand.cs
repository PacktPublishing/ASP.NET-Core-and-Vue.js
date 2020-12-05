using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Travel.Application.Common.Interfaces;
using Travel.Application.Dtos.Tour;
using Travel.Domain.Entities;

namespace Travel.Application.TourLists.Commands.CreateTourList
{
    public partial class CreateTourListCommand : IRequest<TourListDto>
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string About { get; set; }
    }

    public class CreateTourListCommandHandler : IRequestHandler<CreateTourListCommand, TourListDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateTourListCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TourListDto> Handle(CreateTourListCommand request, CancellationToken cancellationToken)
        {
            var entity = new TourList { City = request.City, Country = request.Country, About = request.About };
            _context.TourLists.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            var tourListDto = _mapper.Map<TourListDto>(entity);

            return tourListDto;
        }
    }
}