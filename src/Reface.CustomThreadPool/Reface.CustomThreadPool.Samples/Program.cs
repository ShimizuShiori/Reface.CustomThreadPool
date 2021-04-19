using Reface.CustomThreadPool.Samples.FixedSize;
using System;
using System.Collections.Generic;

namespace Reface.CustomThreadPool.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<IRunner> runners = new List<IRunner>();
            runners.Add(new QuickStart());



            foreach (IRunner runner in runners)
            {
                Console.WriteLine($"开始运行 : {runner.Title}");
                runner.Run();
            }
            Console.WriteLine("完成");
            Console.ReadLine();
        }
    }
}
