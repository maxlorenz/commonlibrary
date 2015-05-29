using Common_Library.Data.Access.Mail;
using System.Collections.Generic;
using System.Net.Mail;

namespace Common_Library.Business.Components
{
    class Mail
    {
        Client client;
        MailMessage message;

        public Mail(string Server, int Port)
        {
            client = new Client(Server, Port);
            message = new MailMessage();
        }

        public void Config(string Sender, string Subject, string Body, IEnumerable<string> To)
        {
            message.From = new MailAddress(Sender);
            message.Subject = Subject;
            message.Body = Body;

            foreach (var address in To)
            {
                message.To.Add(address);
            }
        }

        public void AddAttachement(string Path)
        {
            var attachement = new Attachment(Path);
            message.Attachments.Add(attachement);
        }

        public void Send()
        {
            client.SendMail(message);
        }
    }
}
