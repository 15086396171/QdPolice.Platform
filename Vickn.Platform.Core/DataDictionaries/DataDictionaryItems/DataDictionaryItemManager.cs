/*
* 命名空间 :     Vickn.Platform.DataDictionaries
* 类 名  称 :     DataDictionaryItemManager
* 版      本 :      v1.0.0.0
* 文 件  名 :     DataDictionaryItemManager.cs
* 描      述 :     数据字典项管理
* 创建时间 :     2017/6/12 16:57:18
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace Vickn.Platform.DataDictionaries
{
	 /// <summary>
    /// 数据字典项管理
    /// </summary>
    public class DataDictionaryItemManager : IDomainService
    {
        private readonly IRepository<DataDictionaryItem, int> _dataDictionaryItemRepository;

        /// <summary>
        /// 初始化DataDictionaryItemManager管理实例
        /// </summary>
        public DataDictionaryItemManager(IRepository<DataDictionaryItem, int> dataDictionaryItemRepository)
        {
            _dataDictionaryItemRepository = dataDictionaryItemRepository;
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