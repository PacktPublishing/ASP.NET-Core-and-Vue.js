using AutoMapper;
using Travel.Application.Common.Mappings;
using Travel.Domain.Entities;

namespace Travel.Application.Dtos.Tour
{
    public class TourPackageDto : IMapFrom<TourPackage>
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public bool InstantConfirmation { get; set; }
        public int Currency { get; set; }
        public string WhatToExpect { get; set; }
        public float Price { get; set; }
        public string MapLocation { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TourPackage, TourPackageDto>()
              .ForMember(tpDto =>
                tpDto.Currency, opt =>
                opt.MapFrom(tp =>
                  (int)tp.Currency));
        }
    }
}