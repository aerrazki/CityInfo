﻿using CityInfo.API.Services.Interfaces;

namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;

        public LocalMailService(IConfiguration configuration)
        {
            _mailFrom = configuration["mailSettings:mailFromAddress"];
            _mailTo = configuration["mailSettings:mailToAddress"];
        }
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
