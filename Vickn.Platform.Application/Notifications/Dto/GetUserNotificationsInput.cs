using Abp.Notifications;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.Notifications.Dto
{
    /// <summary>
    /// 获取通知信息的参数
    /// </summary>
    public class GetUserNotificationsInput : PagedAndSortedInputDto
    {
        /// <summary>
        /// 是否阅读枚举 0是未读 1是已经阅读
        /// </summary>
        public UserNotificationState? State { get; set; }
    }
}