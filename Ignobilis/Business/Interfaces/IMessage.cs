using System;

namespace Ignobilis.Business.Interfaces
{

    public interface IMessage
    {
        Guid Id { get; set; }
        string Message { get; set; }
        Uri Link { get; set; }
        string Author { get; set; }

        Util.MessageType Type { get; set; }
    }
}
