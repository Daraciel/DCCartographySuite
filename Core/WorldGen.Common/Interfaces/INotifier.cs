using System;
using WorldGen.Common.EventArgs;

namespace WorldGen.Common.Interfaces
{
    public interface INotifier
    {
        event EventHandler<NotifyEventArgs> Notify;
    }
}
