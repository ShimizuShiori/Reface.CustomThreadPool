using System.Threading;

namespace Reface.CustomThreadPool
{
    /// <summary>
    /// 一个线程池接口
    /// </summary>
    public interface IThreadPool
    {
        /// <summary>
        /// 保持了与 .NetCore 原有线程池的接口
        /// </summary>
        /// <param name="worker">执行器</param>
        /// <param name="arg">参数</param>
        void QueueUserWorkItem(WaitCallback worker, object arg = null);
    }
}
