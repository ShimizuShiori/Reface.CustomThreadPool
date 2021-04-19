using System.Threading;

namespace Reface.CustomThreadPool
{
    public class WorkerInfo
    {
        public WaitCallback Worker { get; private set; }
        public object Arg { get; private set; }

        public WorkerInfo(WaitCallback worker, object arg)
        {
            Worker = worker;
            Arg = arg;
        }
    }
}
