namespace Vickn.Platform.WorkerPxoxy
{
    /// <summary>
    /// 工作者类接口
    /// </summary>
    public interface IBackgroundWorkerDo
    {
        /// <summary>
        /// 执行具体任务
        /// </summary>
        void DoWork();
    }
}