using System.Threading.Tasks;
using Travel.Application.Dtos.Email;

namespace Travel.Application.Common.Interfaces
{
  public interface IEmailService
  {
    Task SendAsync(EmailDto emailRequest);
  }
}