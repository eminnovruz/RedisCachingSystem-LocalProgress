using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AzureRedisCachingSystem.Services.Abstract;
using AzureRedisCachingSystem.Configurations;

namespace AzureRedisCachingSystem.Services
{
    public class CacheMailService : ICacheMailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _fromAddress;

        public CacheMailService(IOptions<SmtpConfig> smtpSettings)
        {
            var settings = smtpSettings.Value;

            _smtpClient = new SmtpClient(settings.Host, settings.Port)
            {
                Credentials = new NetworkCredential(settings.Username, settings.Password),
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            _fromAddress = settings.FromAddress;
        }

        public async Task<bool> NotifyNewCacheObject()
        {
            var subject = "New Cache Object Created";
            var body = "<h1>A new cache object has been created in the system.</h1>";
            return await SendEmail(subject, body);
        }

        public async Task<bool> NotifyUnusedCache()
        {
            var subject = "Unused Cache Object Notification";
            var body = "There are unused cache objects in the system.";
            return await SendEmail(subject, body);
        }

        public async Task<bool> SendCustom(string subject, string body)
        {
            return await SendEmail(subject, body);
        }

        public async Task<bool> SendMetrics(string metrics)
        {
            var subject = "Cache Metrics Report";
            var body = $"Here are the cache metrics:\n{metrics}";
            return await SendEmail(subject, body);
        }

        private async Task<bool> SendEmail(string subject, string body)
        {
            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_fromAddress),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(new MailAddress("myprojectnotifications3@gmail.com"));

                await _smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error sending email: {ex.Message}");
                return false;
            }
        }
    }
}
