using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Application.Dtos.Email
{
  public class EmailDto
  {
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string From { get; set; }
  }
}