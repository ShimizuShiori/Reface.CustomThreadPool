using System;
using System.Threading;

namespace Reface.CustomThreadPool.ThreadStarters
{
    public interface IThreadStarter
    {
        string ThreadStarterType { get; }

        void StartThread(Action action);
    }
}
