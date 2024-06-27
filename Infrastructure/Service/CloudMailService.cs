using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class CloudMailService : IMailService
    {
        private readonly string _mailFrom = string.Empty;

        public CloudMailService(IConfiguration configuration)
        {
            _mailFrom = configuration["mailSettings:mailFromAddress"];
        }

        public void Send(string seller, string message, string mailTo)
        {
            Console.WriteLine($"Mail de {_mailFrom} a {mailTo}, " +
                $"con {nameof(CloudMailService)}.");
            Console.WriteLine($"Seller: {seller}");
            Console.WriteLine($"Mensaje: {message}");
        }
    }
}
