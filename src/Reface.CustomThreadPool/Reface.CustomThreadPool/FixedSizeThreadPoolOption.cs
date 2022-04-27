using Reface.CustomThreadPool.ThreadStarters;

namespace Reface.CustomThreadPool
{
    public class FixedSizeThreadPoolOption
    {
        public int Size { get; set; } = 1;

        public string ThreadStarterType = ThreadPoolStarter.TYPE;
    }
}
