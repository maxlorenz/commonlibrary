using Common_Library.Business.Components;
using System;
using System.Collections.Generic;

namespace Common_Library.Services
{
    public class MailService
    {
        Mail mail;

        public MailService(string Server, int Port)
        {
            mail = new Mail(Server, Port);
        }

        public void Send(string Sender, string Subject, string Body, IEnumerable<string> To)
        {
            mail.Config(Sender, Subject, Body, To);
            mail.Send();
        }

        public void AddAttachement(String Path)
        {
            mail.AddAttachement(Path);
        }
    }
}
