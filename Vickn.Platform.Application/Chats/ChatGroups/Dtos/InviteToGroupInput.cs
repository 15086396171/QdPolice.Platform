using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Vickn.Platform.Chats.ChatGroups.Dtos
{
    public class InviteToGroupInput
    {
        /// <summary>
        /// 群组名
        /// </summary>
        public long GroupId { get; set; }

        public List<EntityDto<long>> UserIds { get; set; }
    }
}