using System;
using System.Net.Http;

namespace Cs7.Helpers
{
    public class Message
    {
        public string Subject { get; set; }
        public string Body { get; set; }

        public Message(string subject, string body)
        {
            Subject = subject;
            Body = body;
        }

        public void Deconstruct(out string subject, out string body)
        {
            subject = Subject;
            body = Body;
        }
    }
}
