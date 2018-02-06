using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Vickn.Platform.Zero.Users.Dtos;

namespace Vickn.Platform.Chats.ChatGroupUsers.Dtos
{
    [AutoMapFrom(typeof(ChatGroupUser))]
    public class ChatGroupUserDto : EntityDto<long>
    {
        /// <summary>
        /// 群组Id
        /// </summary>
        public long ChatGroupId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public UserSimpleDto User { get; set; }
    }
}