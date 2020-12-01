using System.Collections.Generic;

namespace Travel.Domain.Entities
{
  public class TourList
  {
    public TourList()
    {
      Tours = new List<TourPackage>();
    }

    public IList<TourPackage> Tours { get; set; }
    public int Id { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string About { get; set; }
  }
}