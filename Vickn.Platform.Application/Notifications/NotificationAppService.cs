﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Notifications;
using Abp.Runtime.Session;
using Vickn.Platform.Notifications.Dto;
using Vickn.Platform.Zero.Notifications;

namespace Vickn.Platform.Notifications
{
    [AbpAuthorize]
    public class NotificationAppService : PlatformAppServiceBase, INotificationAppService
    {
        private readonly INotificationDefinitionManager _notificationDefinitionManager;
        private readonly IUserNotificationManager _userNotificationManager;
        private readonly INotificationSubscriptionManager _notificationSubscriptionManager;
        private readonly NotificationManager _notificationManager;

        public NotificationAppService(
            INotificationDefinitionManager notificationDefinitionManager,
            IUserNotificationManager userNotificationManager,
            INotificationSubscriptionManager notificationSubscriptionManager, NotificationManager notificationManager)
        {
            _notificationDefinitionManager = notificationDefinitionManager;
            _userNotificationManager = userNotificationManager;
            _notificationSubscriptionManager = notificationSubscriptionManager;
            _notificationManager = notificationManager;
        }

        [DisableAuditing]
        public async Task<GetNotificationsOutput> GetPagedUserNotificationsAsync(GetUserNotificationsInput input)
        {
            var totalCount = await _userNotificationManager.GetUserNotificationCountAsync(
                AbpSession.ToUserIdentifier(), input.State
                );

            var unreadCount = await _userNotificationManager.GetUserNotificationCountAsync(
                AbpSession.ToUserIdentifier(), UserNotificationState.Unread
                );

            var notifications = await _userNotificationManager.GetUserNotificationsAsync(
                AbpSession.ToUserIdentifier(), input.State, input.SkipCount, input.MaxResultCount
                );

            return new GetNotificationsOutput(totalCount, unreadCount, notifications);
        }

        public async Task MakeAllUserNotificationsAsRead()
        {

            await _userNotificationManager.UpdateAllUserNotificationStatesAsync(AbpSession.ToUserIdentifier(), UserNotificationState.Read);
        }

        public async Task MakeNotificationAsRead(EntityDto<Guid> input)
        {
            var userNotification = await _userNotificationManager.GetUserNotificationAsync(AbpSession.TenantId, input.Id);
            if (userNotification.UserId != AbpSession.GetUserId())
            {

                throw new ApplicationException($"消息Id为{input.Id}的信息，不属于当前的用户，用户id：{AbpSession.UserId}");
            }

            await _userNotificationManager.UpdateUserNotificationStateAsync(AbpSession.TenantId, input.Id, UserNotificationState.Read);
        }

        public async Task<GetNotificationSettingsOutput> GetNotificationSettings()
        {
            var output = new GetNotificationSettingsOutput
            {
                ReceiveNotifications =
                    await SettingManager.GetSettingValueAsync<bool>(NotificationSettingNames.ReceiveNotifications),
                Notifications = (await _notificationDefinitionManager
                        .GetAllAvailableAsync(AbpSession.ToUserIdentifier()))
                    .Where(nd => nd.EntityType == null) //Get general notifications, not entity related notifications.
                    .MapTo<List<NotificationSubscriptionWithDisplayNameDto>>()
            };

            var subscribedNotifications = (await _notificationSubscriptionManager
                .GetSubscribedNotificationsAsync(AbpSession.ToUserIdentifier()))
                .Select(ns => ns.NotificationName)
                .ToList();

            output.Notifications.ForEach(n => n.IsSubscribed = subscribedNotifications.Contains(n.Name));

            return output;
        }
        /// <summary>
        /// 更新消息设置
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateNotificationSettings(UpdateNotificationSettingsInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), NotificationSettingNames.ReceiveNotifications, input.ReceiveNotifications.ToString());

            foreach (var notification in input.Notifications)
            {
                if (notification.IsSubscribed)
                {
                    await _notificationSubscriptionManager.SubscribeAsync(AbpSession.ToUserIdentifier(), notification.Name);
                }
                else
                {
                    await _notificationSubscriptionManager.UnsubscribeAsync(AbpSession.ToUserIdentifier(), notification.Name);
                }
            }
        }

        /// <summary>
        /// 发送测试消息
        /// </summary>
        /// <returns></returns>
        public async Task SendTestNotification()
        {
            await _notificationManager.SendMessageAsync((await GetCurrentUserAsync()).ToUserIdentifier(), "这是测试消息，很长很长的测试消息，真的很长");
        }
    }
}