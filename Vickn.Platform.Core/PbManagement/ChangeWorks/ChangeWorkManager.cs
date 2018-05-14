/*
* 命名空间 :     Vickn.Platform.PbManagement.ChangWorks
* 类 名  称 :     ChangeWorkManager
* 版      本 :      v1.0.0.0
* 文 件  名 :     ChangeWorkManager.cs
* 描      述 :     换班管理
* 创建时间 :     2018/5/14 9:16:03
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace Vickn.Platform.PbManagement.ChangeWorks
{
	 /// <summary>
    /// 换班管理
    /// </summary>
    public class ChangeWorkManager : IDomainService
    {
        private readonly IRepository<ChangeWork, long> _changeWorkRepository;

        /// <summary>
        /// 初始化ChangeWorkManager管理实例
        /// </summary>
        public ChangeWorkManager(IRepository<ChangeWork, long> changeWorkRepository)
        {
            _changeWorkRepository = changeWorkRepository;
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