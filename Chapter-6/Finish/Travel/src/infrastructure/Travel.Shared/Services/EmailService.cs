

using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using Travel.Application.Common.Exceptions;
using Travel.Application.Common.Interfaces;
using Travel.Application.Dtos.Email;
using Travel.Domain.Settings;

namespace Travel.Shared.Services
{
  public class EmailService : IEmailService
  {
    public MailSettings _mailSettings { get; }
    public ILogger<EmailService> _logger { get; }

    public EmailService(IOptions<MailSettings> mailSettings, ILogger<EmailService> logger)
    {
      _mailSettings = mailSettings.Value;
      _logger = logger;
    }

    public async Task SendAsync(EmailDto request)
    {
      try
      {
        // create message
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(request.From ?? _mailSettings.EmailFrom);
        email.To.Add(MailboxAddress.Parse(request.To));
        email.Subject = request.Subject;
        var builder = new BodyBuilder();
        builder.HtmlBody = request.Body;
        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();

        await smtp.SendAsync(email);

        smtp.Disconnect(true);
      }
      catch (System.Exception ex)
      {
        _logger.LogError(ex.Message, ex);
        throw new ApiException(ex.Message);
      }
    }
  }
}