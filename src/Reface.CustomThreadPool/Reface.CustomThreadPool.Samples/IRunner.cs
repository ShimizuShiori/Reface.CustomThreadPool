namespace Reface.CustomThreadPool.Samples
{
    public interface IRunner
    {
        string Title { get; }
        void Run();
    }
}
