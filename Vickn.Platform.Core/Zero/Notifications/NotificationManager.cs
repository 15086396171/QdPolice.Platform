using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Notifications;
using Vickn.Platform.Users;

namespace Vickn.Platform.Zero.Notifications
{
    public class NotificationManager : DomainService
    {

        private readonly INotificationPublisher _notificationPublisher;
        private readonly IRepository<User, long> _userRepository;
        public NotificationManager(INotificationPublisher notificationPublisher, IRepository<User, long> userRepository)
        {
            _notificationPublisher = notificationPublisher;
            _userRepository = userRepository;
        }
        public async Task WelcomeToAsync(User user)
        {
            await _notificationPublisher.PublishAsync(
                PlatformConsts.NotificationConstNames.WelcomeToCms,
                new MessageNotificationData(L("WelcomeToCms")), severity: NotificationSeverity.Success,
                userIds: new[] { user.ToUserIdentifier() });
        }

        /// <summary>
        /// 发送不带数据的简单通知
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <param name="severity"></param>
        /// <returns></returns>
        public async Task SendMessageAsync(UserIdentifier user, string message, NotificationSeverity severity = NotificationSeverity.Info)
        {
            await SendMessageAsync(user, PlatformConsts.NotificationConstNames.SendMessageAsync, message, severity);
        }

        /// <summary>
        /// 发送通知
        /// </summary>
        /// <param name="user"></param>
        /// <param name="notificationName"></param>
        /// <param name="message"></param>
        /// <param name="data">数据</param>
        /// <param name="severity"></param>
        /// <returns></returns>
        public async Task SendMessageAsync(UserIdentifier user, string notificationName, string message, object data, NotificationSeverity severity = NotificationSeverity.Info)
        {
            await SendMessageAsync(new[] { user }, notificationName, new MessageNotificationData(message)
            {
                Properties = new Dictionary<string, object>()
                {
                    {"Data",data }
                }
            }, severity);
        }

        public async Task SendMessageAsync(UserIdentifier[] users, string notificationName, string message, object data,
            NotificationSeverity severity = NotificationSeverity.Info)
        {
            await SendMessageAsync(users, notificationName, new MessageNotificationData(message)
            {
                Properties = new Dictionary<string, object>()
                {
                    {"Data",data }
                }
            }, severity);
        }

        /// <summary>
        /// 发送包含数据的通知
        /// </summary>
        /// <param name="users"></param>
        /// <param name="notificationName"></param>
        /// <param name="data"></param>
        /// <param name="severity"></param>
        /// <returns></returns>
        private async Task SendMessageAsync(UserIdentifier[] users, string notificationName, MessageNotificationData data, NotificationSeverity severity = NotificationSeverity.Info)
        {
            long[] userIds = users.Select(p => p.UserId).ToArray();
            var userEntities = await _userRepository.GetAllListAsync(p => userIds.Contains(p.Id));

            await _notificationPublisher.PublishAsync(notificationName, data, null, severity, users);

            //foreach (var userEntity in userEntities)
            //{
            //    if (userEntity.UserType == UserType.Parent)
            //        await _jPushParentManager.SendPushAsync(userEntity.PhoneNumber, notificationName, data.Message, notificationName);
            //    else if (userEntity.UserType == UserType.Student)
            //        await _jPushStudentManager.SendPushAsync(userEntity.PhoneNumber, notificationName, data.Message, notificationName);
            //}
        }
    }
}