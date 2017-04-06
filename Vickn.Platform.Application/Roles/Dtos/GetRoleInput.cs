/*
* 命名空间 :     Vickn.Platform.Authorization.Roles.Dtos
* 类 名  称 :     GetRoleInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetRoleInput.cs
* 描      述 :     角色管理分页排序查询输入Dto
* 创建时间 :     2017/2/20 15:47:00
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using Abp.Runtime.Validation;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.Roles.Dtos
{
     /// <summary>
    /// 角色管理查询Dto
    /// </summary>
    public class GetRoleInput : PagedAndSortedInputDto,IShouldNormalize
    {
		//DOTO:在这里增加查询参数

        public string RoleName { get; set; }

		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string FilterText { get; set; }

		/// <summary>
	    /// 用于排序的默认值
		/// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}
