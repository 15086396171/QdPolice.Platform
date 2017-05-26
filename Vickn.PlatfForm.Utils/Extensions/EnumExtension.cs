using System;

namespace Vickn.PlatfForm.Utils.Extensions
{
    /// <summary>
    /// 自定义属性 显示名称
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class EnumDescriptionAttribute : Attribute
    {
        public string Description { get; }

        public EnumDescriptionAttribute(string description)
            : base()
        {
            this.Description = description;
        }
    }

    /// <summary>
    /// 更具
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        ///  获取枚举字符串 显示名称
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns></returns>
        public static string GetDescription(this System.Enum value)
        {
            if (value == null)
            {
                throw new ArgumentException("value");
            }
            string description = value.ToString();
            var fieldInfo = value.GetType().GetField(description);
            var attributes =
                (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
            return description;
        }
    }
}