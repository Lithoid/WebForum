﻿using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MimeKit;

namespace WebApp.Models
{
    public class EmailManager
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Web forum administrator", "mailforsmtpwebforum@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465,true);
                await client.AuthenticateAsync("mailforsmtpwebforum@gmail.com", "czsmxqeioqsbqvze");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}