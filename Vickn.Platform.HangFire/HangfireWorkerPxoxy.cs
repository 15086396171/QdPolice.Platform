using System;
using Abp.Extensions;
using Hangfire;

namespace Vickn.Platform.WorkerPxoxy.HangFire
{
    public class HangfireWorkerPxoxy : IBackgroudWorkerProxy
    {

        public HangfireWorkerPxoxy()
        {

        }
        private WorkerConfig Config { get; set; }

        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="method"></param>
        /// <param name="config"></param>
        public void Excete<T>(Action method, WorkerConfig config) where T : IBackgroundWorkerDo
        {
            Config = config;
            string workerId = config.WorkerId;
            string cron = config.Cron.IsNullOrEmpty() ? Cron.MinuteInterval(config.IntervalSecond / 60) : config.Cron;
            RecurringJob.AddOrUpdate<T>(config.WorkerId, (t) => t.DoWork(), cron, TimeZoneInfo.Local);
            RecurringJob.Trigger(config.WorkerId);
        }
    }
}