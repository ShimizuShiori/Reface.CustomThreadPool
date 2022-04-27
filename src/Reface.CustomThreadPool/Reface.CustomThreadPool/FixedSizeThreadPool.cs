using Reface.CustomThreadPool.ThreadStarters;
using System.Collections.Generic;
using System.Threading;

namespace Reface.CustomThreadPool
{
    /// <summary>
    /// 固定大小的线程池
    /// </summary>
    public class FixedSizeThreadPool : IThreadPool
    {
        private readonly FixedSizeThreadPoolOption option;

        private readonly Queue<WorkerInfo> workerInfoQueue = new Queue<WorkerInfo>();
        private readonly Queue<AutoResetEvent> EventQueue = new Queue<AutoResetEvent>();

        private readonly object LOCKER_Q = new object();
        private readonly object LOCKER_WAIT_EVENTS = new object();

        private readonly IThreadStarter threadStarter;

        public FixedSizeThreadPool(FixedSizeThreadPoolOption option)
        {
            this.option = option;
            this.threadStarter = CreateThreadStarter();
            for (int i = 0; i < option.Size; i++)
                this.threadStarter.StartThread(ExecuteWorkers);
        }

        private IThreadStarter CreateThreadStarter()
        {
            switch (option.ThreadStarterType)
            {
                case ThreadPoolStarter.TYPE:
                    return new ThreadPoolStarter();
                default:
                    return new NewThreadStarter();
            }
        }

        private void ExecuteWorkers()
        {
            AutoResetEvent @event = new AutoResetEvent(false);

            while (true)
            {
                bool hasWorker = false;
                WorkerInfo workerInfo = null;

                while (workerInfo == null)
                {
                    lock (LOCKER_Q)
                    {
                        hasWorker = workerInfoQueue.Count > 0;
                        if (hasWorker) workerInfo = workerInfoQueue.Dequeue();
                    }

                    if (!hasWorker)
                    {
                        lock (LOCKER_WAIT_EVENTS)
                        {
                            EventQueue.Enqueue(@event);
                        }
                        @event.WaitOne();
                    }
                }

                workerInfo.Worker(workerInfo.Arg);
            }
        }

        public void QueueUserWorkItem(WaitCallback worker, object arg = null)
        {
            lock (LOCKER_Q)
            {
                workerInfoQueue.Enqueue(new WorkerInfo(worker, arg));
            }

            lock (LOCKER_WAIT_EVENTS)
            {
                while (EventQueue.Count > 0)
                {
                    EventQueue.Dequeue().Set();
                }
            }

        }
    }
}
