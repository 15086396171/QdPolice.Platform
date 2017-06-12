using Abp.Threading.BackgroundWorkers;

namespace Vickn.Platform.WorkerPxoxy
{
    /// <summary>
    /// 后台工作者基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BackgroundWorker<T>:BackgroundWorkerBase,IBackgroundWorkerDo where T:IBackgroundWorkerDo
    {
        protected readonly IBackgroudWorkerProxy _workProxy;
        protected readonly WorkerConfig _config;
        protected BackgroundWorker(IBackgroudWorkerProxy workProxy, WorkerConfig config)
        {
            _workProxy = workProxy;
            _config = config;
        }

        /// <summary>
        /// 任务启动
        /// </summary>
        public override void Start()
        {
            Logger.Debug("轮询任务启动");
            _workProxy.Excete<T>(DoWork, _config); //主要指定当前任务类，不然hangfire无法调用，不然可以移到父类去
        }
        /// <summary>
        /// 具体的任务执行
        /// </summary>
        public abstract void DoWork();
    }
}