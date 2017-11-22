/*
* 命名空间 :     Vickn.Platform.FileRecords
* 类 名  称 :     FileRecordManager
* 版      本 :      v1.0.0.0
* 文 件  名 :     FileRecordManager.cs
* 描      述 :     文件记录管理
* 创建时间 :     2017/8/13 22:00:22
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace Vickn.Platform.FileRecords
{
	 /// <summary>
    /// 文件记录管理
    /// </summary>
    public class FileRecordManager : IDomainService
    {
        private readonly IRepository<FileRecord, int> _fileRecordRepository;

        /// <summary>
        /// 初始化FileRecordManager管理实例
        /// </summary>
        public FileRecordManager(IRepository<FileRecord, int> fileRecordRepository)
        {
            _fileRecordRepository = fileRecordRepository;
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