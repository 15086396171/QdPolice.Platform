namespace Vickn.Platform.WorkerPxoxy
{
    /// <summary>
    /// 工作任务配置
    /// </summary>
    public class WorkerConfig
    {
        /// <summary>
        /// 轮询秒数
        /// </summary>
        public int IntervalSecond { get; set; }
        /// <summary>
        /// 工作唯一编号
        /// </summary>
        public string WorkerId { get; set; }

        /// <summary>
        /// 时间轮询规则，为空则按照轮询秒数执行
        /// </summary>
        public string Cron { get; set; }
    }
}