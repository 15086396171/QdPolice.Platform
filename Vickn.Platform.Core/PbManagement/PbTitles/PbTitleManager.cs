/*
* 命名空间 :     Vickn.Platform.PbManagement.PbTitles
* 类 名  称 :     PbTitleManager
* 版      本 :      v1.0.0.0
* 文 件  名 :     PbTitleManager.cs
* 描      述 :     排班标题管理
* 创建时间 :     2018/5/6 14:40:35
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace Vickn.Platform.PbManagement.PbTitles
{
	 /// <summary>
    /// 排班标题管理
    /// </summary>
    public class PbTitleManager : IDomainService
    {
        private readonly IRepository<PbTitle, int> _pbTitleRepository;

        /// <summary>
        /// 初始化PbTitleManager管理实例
        /// </summary>
        public PbTitleManager(IRepository<PbTitle, int> pbTitleRepository)
        {
            _pbTitleRepository = pbTitleRepository;
        }

        //TODO:编写领域业务代码

        /// <summary>
        ///  初始化
        /// </summary>
        private void Init()
        {
        }
    }
}