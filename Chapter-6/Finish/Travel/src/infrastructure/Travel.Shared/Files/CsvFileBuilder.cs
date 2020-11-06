using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Travel.Application.Common.Interfaces;
using Travel.Application.TourLists.Queries.ExportTours;

namespace Travel.Shared.Files
{
  public class CsvFileBuilder : ICsvFileBuilder
  {
    public byte[] BuildTourPackagesFile(IEnumerable<TourPackageRecord> records)
    {
      using var memoryStream = new MemoryStream();
      using (var streamWriter = new StreamWriter(memoryStream))
      {
        using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
        csvWriter.WriteRecords(records);
      }

      return memoryStream.ToArray();
    }
  }
}