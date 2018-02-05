using System;
using System.Threading.Tasks;
using Abp;
using Abp.Dependency;
using Abp.Notifications;
using Abp.RealTime;
using Abp.Web.SignalR.Hubs;
using Abp.Web.SignalR.Notifications;
using Castle.Core.Logging;
using Microsoft.AspNet.SignalR;
using Vickn.Platform.Chats;

namespace Vickn.Platform.RealTime
{
    /// <summary>
    /// 替换默认的实时通知系统
    /// </summary>
    public class MySignalrRealTimeNotifier : IRealTimeNotifier, ITransientDependency
    {
        /// <summary>
        /// Reference to the logger.
        /// </summary>
        public ILogger Logger { get; set; }

        private readonly IOnlineClientManager _onlineClientManager;

        private static IHubContext CommonHub
        {
            get { return GlobalHost.ConnectionManager.GetHubContext<PoliceCommonHub>(); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalRRealTimeNotifier"/> class.
        /// </summary>
        public MySignalrRealTimeNotifier(IOnlineClientManager onlineClientManager)
        {
            _onlineClientManager = onlineClientManager;
            Logger = NullLogger.Instance;
        }

        /// <inheritdoc/>
        public Task SendNotificationsAsync(UserNotification[] userNotifications)
        {
            foreach (var userNotification in userNotifications)
            {
                try
                {
                    var onlineClients = _onlineClientManager.GetAllByUserId(userNotification);
                    foreach (var onlineClient in onlineClients)
                    {
                        var signalRClient = CommonHub.Clients.Client(onlineClient.ConnectionId);
                        if (signalRClient == null)
                        {
                            Logger.Debug("Can not get user " + userNotification.ToUserIdentifier() +
                                         " with connectionId " + onlineClient.ConnectionId + " from SignalR hub!");
                            continue;
                        }

                        signalRClient.getNotification(userNotification);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Warn("Could not send notification to user: " + userNotification.ToUserIdentifier());
                    Logger.Warn(ex.ToString(), ex);
                }
            }

            return Task.FromResult(0);
        }
    }
}