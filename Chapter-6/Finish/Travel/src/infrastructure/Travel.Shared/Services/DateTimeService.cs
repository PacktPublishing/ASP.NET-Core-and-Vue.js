using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.Common.Interfaces;

namespace Travel.Shared.Services
{
  public class DateTimeService : IDateTime
  {
    public DateTime NowUtc => DateTime.UtcNow;
  }
}