using System.Net.Mail;

namespace Common_Library.Data.Access.Mail
{
    class Client
    {
        SmtpClient client;

        public Client(string Server, int Port)
        {
            client = new SmtpClient(Server, Port);
        }

        public void SendMail(MailMessage Mail)
        {
            client.Send(Mail);
        }
    }
}
