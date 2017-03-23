using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs7.Helpers
{
    public interface IMessageProvider
    {
        ValueTask<Message> GetMostRecentMessage();
    }

    public class MessageProvider : IMessageProvider
    {
        private readonly ConcurrentDictionary<DateTimeOffset, Message> _messages = new ConcurrentDictionary<DateTimeOffset, Message>();

        public MessageProvider() => _messages.TryAdd(DateTimeOffset.Now, new Message("Some message", "This message came from memory"));

        public ValueTask<Message> GetMostRecentMessage()
        {
            return new ValueTask<Message>(_messages.OrderByDescending(m => m.Key).FirstOrDefault().Value);
        }
    }

    public class DbMessageProvider : IMessageProvider
    {
        public async ValueTask<Message> GetMostRecentMessage()
        {
            return await Task.Run(async () =>
            {
                await Task.Delay(1000);
                return new Message("Some other message", "This message came from the database");
            });
        }
    }
}
