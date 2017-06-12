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
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Extensions;
using Abp.Runtime.Caching;

namespace Vickn.Platform.DataDictionaries
{
    /// <summary>
    /// 数据字典管理
    /// </summary>
    public class DataDictionaryManager : IDomainService
    {
        private readonly IRepository<DataDictionary, int> _dataDictionaryRepository;
        private readonly ICacheManager _cacheManager;

        /// <summary>
        /// 初始化DataDictionaryManager管理实例
        /// </summary>
        public DataDictionaryManager(IRepository<DataDictionary, int> dataDictionaryRepository, ICacheManager cacheManager)
        {
            _dataDictionaryRepository = dataDictionaryRepository;
            _cacheManager = cacheManager;
        }

        //TODO:编写领域业务代码

        /// <summary>
        ///  初始化
        /// </summary>
        private void Init()
        {
        }

        /// <summary>
        /// 根据键获取字典值字符串集合
        /// </summary>
        /// <param name="dataDicKey"></param>
        /// <returns></returns>
        public async Task<List<string>> GetDataDictionaryItemsAsync(string dataDicKey)
        {
            var dataDictionary = await GetDataDictionaryAsync(dataDicKey);
            return dataDictionary.DataDictionaryItems.Select(p => p.Value).ToList();
        }

        /// <summary>
        /// 根据键获取字典值指定类型集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataDicKey"></param>
        /// <returns></returns>
        public async Task<List<T>> GetDataDictionaryItemsAsync<T>(string dataDicKey) where T : struct
        {
            var dataDictionary = await GetDataDictionaryAsync(dataDicKey);
            return dataDictionary.DataDictionaryItems.Select(p => p.Value.To<T>()).ToList();
        }

        /// <summary>
        /// 获取数据字典键和值的集合
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<DataDictionary> GetDataDictionaryAsync(string key)
        {
            return await _cacheManager.GetCache(key)
                .GetAsync(key, async () => await GetDataDictionaryFromDatabaseAsync(key));
        }

        private async Task<DataDictionary> GetDataDictionaryFromDatabaseAsync(string key)
        {
            return await _dataDictionaryRepository.FirstOrDefaultAsync(p => p.Key == key);
        }
    }
}