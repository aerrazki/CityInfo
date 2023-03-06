using CityInfo.API.Services.Interfaces;

namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {
        private string _mailTo = "ok@company.com";
        public string _mailFrom = "noreply@mycompany.com";

        public void Send(string subject, string message)
        {
            if (!(string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message)))
            {
                var mail = $"Mail from {_mailFrom} to {_mailTo}, with {nameof(LocalMailService)}";
                Console.Write(mail);
                Console.WriteLine($"Subject: {subject}");
                Console.WriteLine($"Message: {message}");

            }
        }
    }
}
