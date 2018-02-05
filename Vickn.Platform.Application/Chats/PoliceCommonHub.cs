using Abp.RealTime;
using Abp.Web.SignalR.Hubs;

namespace Vickn.Platform.Chats
{
    /// <summary>
    /// 集中hub管理
    /// </summary>
    public class PoliceCommonHub:AbpCommonHub
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Abp.Web.SignalR.Hubs.AbpCommonHub" /> class.
        /// </summary>
        public PoliceCommonHub(IOnlineClientManager onlineClientManager) : base(onlineClientManager)
        {
        }
    }
}