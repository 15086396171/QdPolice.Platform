using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Vickn.Platform.Users;

namespace Vickn.Platform.Organizations.Dto
{
    [AutoMapFrom(typeof(User))]
    public class OrganizationUnitUserListDto : EntityDto<long>
    {
        public bool IsChecked { get; set; }
        public string Name { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public DateTime AddedTime { get; set; }
    }
}