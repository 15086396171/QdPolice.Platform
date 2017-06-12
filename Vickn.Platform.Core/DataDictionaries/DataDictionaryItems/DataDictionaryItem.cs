using Abp.Domain.Entities;

namespace Vickn.Platform.DataDictionaries
{
    /// <summary>
    /// 数据字典项
    /// </summary>
    public class DataDictionaryItem : Entity
    {
        public DataDictionaryItem(string displayName, string value)
        {
            this.DisplayName = displayName;
            this.Value = value;
        }

        /// <summary>
        /// 显示
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 键Id
        /// </summary>
        public int DataDictionaryId { get; set; }
    }
}