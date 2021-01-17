using System;

namespace Travel.Application.Common.Interfaces
{
  public interface IDateTime
  {
    DateTime NowUtc { get; }
  }
}