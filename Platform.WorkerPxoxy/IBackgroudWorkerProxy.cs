using System;

namespace Vickn.Platform.WorkerPxoxy
{
    /// <summary>
    /// 后台工作者代理接口
    /// </summary>
    public interface IBackgroudWorkerProxy
    {
        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="method"></param>
        void Excete<T>(Action method, WorkerConfig config) where T : IBackgroundWorkerDo;
    }
}