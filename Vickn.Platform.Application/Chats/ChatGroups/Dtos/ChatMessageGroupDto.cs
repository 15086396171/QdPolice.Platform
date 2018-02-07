using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.Chats.ChatGroups.Dtos
{
    [AutoMapFrom(typeof(ChatGroup))]
    public class ChatMessageGroupDto:EntityDto<long>
    {
        /// <summary>
        /// 群组名称
        /// </summary>
        public string Name { get; set; }
    }
}