namespace Reface.CustomThreadPool
{
    /// <summary>
    /// 单个线程的线程池
    /// </summary>
    public class SingleThreadPool : FixedSizeThreadPool
    {
        public SingleThreadPool() : base(new FixedSizeThreadPoolOption() { Size = 1 })
        {

        }
    }
}
