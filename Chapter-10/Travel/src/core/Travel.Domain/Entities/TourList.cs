using System.Collections.Generic;

namespace Travel.Domain.Entities
{
    public class TourList
    {
        public TourList()
        {
            TourPackages = new List<TourPackage>();
        }

        public IList<TourPackage> TourPackages { get; set; }
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string About { get; set; }
    }
}