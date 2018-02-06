using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Vickn.Platform.Chats.ChatGroupUsers.Dtos;

namespace Vickn.Platform.Chats.ChatGroups.Dtos
{
    [AutoMapFrom(typeof(ChatGroup))]
    public class ChatGroupDto:EntityDto<long>
    {
        /// <summary>
        /// 群组名称
        /// </summary>
        public string Name { get; set; }

        public List<ChatGroupUserDto> ChatGroupUsers { get; set; }
    }
}