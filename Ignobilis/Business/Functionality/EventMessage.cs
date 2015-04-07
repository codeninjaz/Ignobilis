using System;
using Ignobilis.Business.Interfaces;

namespace Ignobilis.Business.Functionality
{
    public class EventMessage : IMessage
    {
        public EventMessage()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Message { get; set; }
        public Uri Link { get; set; }
        public string Author { get; set; }
        public Util.MessageType Type { get; set; }
    }
}