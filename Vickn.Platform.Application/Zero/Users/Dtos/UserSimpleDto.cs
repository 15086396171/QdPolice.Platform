using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Vickn.Platform.Users;

namespace Vickn.Platform.Zero.Users.Dtos
{
    [AutoMapFrom(typeof(User))]
    public class UserSimpleDto:EntityDto<long>
    { 
        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName("用户名")]
        public string UserName { get; set; }
        /// <summary>
        /// 警号
        /// </summary>
        public string PoliceNo { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 职务Id
        /// </summary>
        public string PositionId { get; set; }

        /// <summary>
        /// 电话号码.
        /// </summary>
        [DisplayName("电话号码.")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 座机
        /// </summary>
        public string Landline { get; set; }
    }
}