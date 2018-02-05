/*
* 命名空间 :     Vickn.Platform.HandheldTerminals
* 类 名  称 :     ForensicsRecordManager
* 版      本 :      v1.0.0.0
* 文 件  名 :     ForensicsRecordManager.cs
* 描      述 :     取证记录管理
* 创建时间 :     2018/2/5 17:40:06
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace Vickn.Platform.HandheldTerminals
{
	 /// <summary>
    /// 取证记录管理
    /// </summary>
    public class ForensicsRecordManager : IDomainService
    {
        private readonly IRepository<ForensicsRecord, long> _forensicsRecordRepository;

        /// <summary>
        /// 初始化ForensicsRecordManager管理实例
        /// </summary>
        public ForensicsRecordManager(IRepository<ForensicsRecord, long> forensicsRecordRepository)
        {
            _forensicsRecordRepository = forensicsRecordRepository;
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