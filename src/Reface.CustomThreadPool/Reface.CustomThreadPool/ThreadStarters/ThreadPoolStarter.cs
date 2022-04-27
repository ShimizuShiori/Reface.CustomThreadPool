using System;
using System.Threading;

namespace Reface.CustomThreadPool.ThreadStarters
{
    public class ThreadPoolStarter : IThreadStarter
    {
        public const string TYPE = "ThreadPool";

        public string ThreadStarterType => TYPE;

        public void StartThread(Action action)
        {
            ThreadPool.QueueUserWorkItem(s => action());
        }
    }
}
