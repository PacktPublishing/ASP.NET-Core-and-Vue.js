using System.Collections.Generic;
using Travel.Application.TourLists.Queries.ExportTours;

namespace Travel.Application.Common.Interfaces
{
  public interface ICsvFileBuilder
  {
    byte[] BuildTourPackagesFile(IEnumerable<TourPackageRecord> records);
  }
}