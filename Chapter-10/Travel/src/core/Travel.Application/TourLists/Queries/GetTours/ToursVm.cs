using System.Collections.Generic;
using Travel.Application.Dtos.Tour;

namespace Travel.Application.TourLists.Queries.GetTours
{
  public class ToursVm
  {
    public IList<TourListDto> Lists { get; set; }
  }
}