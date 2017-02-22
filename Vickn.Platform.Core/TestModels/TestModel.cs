using System;
using System.Collections.Generic;
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

        public decimal Decimal { get; set; }

        public virtual ICollection<TestModelChild> TestModelChildren { get; set; }

    }

    public class TestModelChild:FullAuditedEntity
    {
        public int TestModelId { get; set; }

        public string Test { get; set; }
    }

    public class TestModelBrother
    {
        
    }
}