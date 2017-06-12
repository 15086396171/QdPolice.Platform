using System;
using Abp.Threading.Timers;

namespace Vickn.Platform.WorkerPxoxy
{
    /// <summary>
    /// 后台工作者代理基类
    /// </summary>
    public class PeriodicWorkerPxoxy : IBackgroudWorkerProxy
    {
        private Action ExetuteMethod { get; set; }
        protected readonly AbpTimer Timer;
        public PeriodicWorkerPxoxy(AbpTimer timer)
        {
            Timer = timer;
            Timer.Elapsed += Timer_Elapsed;
        }
        private void Timer_Elapsed(object sender, EventArgs e)
        {
            try
            {
                DoWork();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="method"></param>
        public void Excete<T>(Action method, WorkerConfig config) where T : IBackgroundWorkerDo
        {
            config.IntervalSecond = config.IntervalSecond == 0 ? 3600 : config.IntervalSecond;
            ExetuteMethod = method;
            Timer.Period = config.IntervalSecond * 1000;//将传入的秒数转化为毫秒
            Timer.Start();
        }

        protected void DoWork()
        {
            ExetuteMethod();
        }
    }
}