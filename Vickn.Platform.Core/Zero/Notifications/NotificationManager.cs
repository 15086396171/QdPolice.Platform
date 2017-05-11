using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using Abp.Notifications;
using Vickn.Platform.Users;

namespace Vickn.Platform.Zero.Notifications
{
    public class NotificationManager : DomainService, INotificationManager
    {
        private readonly INotificationPublisher _notificationPublisher;
        public NotificationManager(INotificationPublisher notificationPublisher)
        {
            _notificationPublisher = notificationPublisher;
        }
        public async Task WelcomeToAsync(User user)
        {
            await _notificationPublisher.PublishAsync(
                PlatformConsts.NotificationConstNames.WelcomeToCms,
                new MessageNotificationData(L("WelcomeToCms")), severity: NotificationSeverity.Success,
                userIds: new[] { user.ToUserIdentifier() });

        }

        public async Task SendMessageAsync(UserIdentifier user, string message, NotificationSeverity severity = NotificationSeverity.Info)
        {
            await _notificationPublisher.PublishAsync(
                PlatformConsts.NotificationConstNames.SendMessageAsync,
                new MessageNotificationData(message), severity: severity, userIds: new[] { user });
        }
    }
}