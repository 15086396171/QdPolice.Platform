using System.Threading.Tasks;
using Abp;
using Abp.Notifications;
using Vickn.Platform.Users;

namespace Vickn.Platform.Zero.Notifications
{
    public interface INotificationManager
    {
        Task WelcomeToAsync(User user);

        Task SendMessageAsync(UserIdentifier user, string message,
            NotificationSeverity severity = NotificationSeverity.Info);
    }
}