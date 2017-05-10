using System.Collections.Generic;

namespace Vickn.Platform.Organizations.Dto
{
    public class AddUserToOuInput
    {
        /// <summary>
        /// 组织Id
        /// </summary>
        public long OuId { get; set; }

        /// <summary>
        /// 删除用户Id
        /// </summary>
        public List<long> DelUserIds { get; set; }

        /// <summary>
        /// 加入用户或不变的Id
        /// </summary>
        public List<long> UserIds { get; set; }

    }
}