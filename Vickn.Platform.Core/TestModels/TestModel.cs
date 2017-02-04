using System;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Vickn.Platform.TestModels
{
    public class TestModel : FullAuditedEntity<string>
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }

    }
}