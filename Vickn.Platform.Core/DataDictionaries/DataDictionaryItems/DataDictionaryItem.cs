using Abp.Domain.Entities;

namespace Vickn.Platform.DataDictionaries
{
    /// <summary>
    /// 数据字典项
    /// </summary>
    public class DataDictionaryItem : Entity
    {
        public DataDictionaryItem()
        {

        }
        public DataDictionaryItem(string displayName, string value)
        {
            this.DisplayName = displayName;
            this.Value = value;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 上级编号
        /// </summary>
        public string ParentNo { get; set; }

        /// <summary>
        /// 扩展字段，按*分隔
        /// </summary>
        public string Extend { get; set; }

        /// <summary>
        /// 键Id
        /// </summary>
        public int DataDictionaryId { get; set; }
    }
}