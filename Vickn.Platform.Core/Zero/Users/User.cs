using System;
using Abp.Authorization.Users;
using Abp.Extensions;
using Microsoft.AspNet.Identity;

namespace Vickn.Platform.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "88888888";

        public virtual string ProfilePictureId { get; set; }

        /// <summary>
        /// 警号
        /// </summary>
        public string PoliceNo { get; set; }

        /// <summary>
        /// 座机
        /// </summary>
        public string Landline { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 职务Id
        /// </summary>
        public string PositionId { get; set; }

        public virtual bool ShouldChangePasswordOnNextLogin { get; set; }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress, string password)
        {
            return new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Password = new PasswordHasher().HashPassword(password)
            };
        }
    }
}