using System;
using System.Collections.Generic;
using System.Linq;
using MailKit;
using MimeKit;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace ChessTournament.IL.Tools
{
    public class MailManager
    {
        public void SendEmail(string recipientMailAddress, string recipientName, string content, string subject)
        {
            string sender = "net2022@khunly.be";
            string password = "test1234=";

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("M. Checkmate", sender));
            message.To.Add(new MailboxAddress(recipientName, recipientMailAddress));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = content};

            using (var client = new SmtpClient())
            {
                // ??????
                client.Connect(sender, 587, false);
                client.Authenticate(sender, password);

                try
                {
                    client.Send(message);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                }
                
            }
        }
    }

}
