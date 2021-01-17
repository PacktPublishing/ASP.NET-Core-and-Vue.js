using FluentValidation;

namespace Travel.Application.TourPackages.Queries
{
    public class GetTourPackagesQueryValidator : AbstractValidator<GetTourPackagesQuery>
    {
        public GetTourPackagesQueryValidator()
        {
            RuleFor(x => x.ListId)
                .NotNull()
                .NotEmpty().WithMessage("ListId is required.");
        }
    }
}