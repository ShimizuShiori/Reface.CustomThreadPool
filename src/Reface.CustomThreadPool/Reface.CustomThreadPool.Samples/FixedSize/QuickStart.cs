using Reface.CustomThreadPool.ThreadStarters;
using System;
using System.Linq;
using System.Threading;

namespace Reface.CustomThreadPool.Samples.FixedSize
{
    public class QuickStart : IRunner
    {
        public string Title => "快速开始";

        public void Run()
        {
            FixedSizeThreadPoolOption option = new FixedSizeThreadPoolOption()
            {
                Size = 2,
                ThreadStarterType = ThreadPoolStarter.TYPE
            };

            IThreadPool tp = new FixedSizeThreadPool(option);

            Enumerable.Range(1, 10)
                .Select(i =>
                {
                    tp.QueueUserWorkItem(state =>
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] : {state}");
                    }, i);
                    return i;
                })
                .ToList();
        }
    }
}
