/*
* 命名空间 :     Vickn.Platform.DataDictionaries
* 类 名  称 :     DataDictionaryManager
* 版      本 :      v1.0.0.0
* 文 件  名 :     DataDictionaryManager.cs
* 描      述 :     数据字典管理
* 创建时间 :     2017/6/12 16:41:29
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
    /// 数据字典管理
    /// </summary>
    public class DataDictionaryManager : IDomainService
    {
        private readonly IRepository<DataDictionary, int> _dataDictionaryRepository;

        /// <summary>
        /// 初始化DataDictionaryManager管理实例
        /// </summary>
        public DataDictionaryManager(IRepository<DataDictionary, int> dataDictionaryRepository)
        {
            _dataDictionaryRepository = dataDictionaryRepository;
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