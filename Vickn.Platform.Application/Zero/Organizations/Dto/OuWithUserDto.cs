using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Organizations;
using Vickn.Platform.Zero.Users.Dtos;

namespace Vickn.Platform.Organizations.Dto
{
    [AutoMapFrom(typeof(OrganizationUnit))]
    public class OuWithUserDto : EntityDto<long>
    {
        public long? ParentId { get; set; }
        public List<OuWithUserDto> Children { get; set; }

        public string DisplayName { get; set; }

        public List<UserSimpleDto> Users { get; set; }
    }
}