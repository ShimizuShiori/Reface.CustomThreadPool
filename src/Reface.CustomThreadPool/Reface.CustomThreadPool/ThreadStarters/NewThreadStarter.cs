using System;
using System.Threading;

namespace Reface.CustomThreadPool.ThreadStarters
{
    public class NewThreadStarter : IThreadStarter
    {
        public const string TYPE = "NewThread";
        public string ThreadStarterType => TYPE;

        public void StartThread(Action action)
        {
            Thread t = new Thread(() => action())
            {
                IsBackground = true
            };
            t.Start();
        }
    }
}
