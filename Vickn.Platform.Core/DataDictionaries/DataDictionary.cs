using System.Collections.Generic;
using Abp.Domain.Entities;

namespace Vickn.Platform.DataDictionaries
{
    /// <summary>
    /// 数据字典
    /// </summary>
    public class DataDictionary : Entity
    {
        /// <summary>
        /// 键名
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 显示名
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 项集合
        /// </summary>
        public virtual ICollection<DataDictionaryItem> DataDictionaryItems { get; set; }
    }
}