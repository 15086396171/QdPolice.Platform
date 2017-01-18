﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Vickn.PlatfForm.Utils
{
    /// <summary>
    /// ULR拼装
    /// </summary>
    internal static class Exts
    {
        public static string GetUrl(this string url, int curIndex, int reps)
        {
            return url.Replace("pageindex=" + curIndex.ToString(), "pageindex=" + reps.ToString());
        }
    }

    /// <summary>
    /// 分页核心代码
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagerResult<T>
    {
        public int Code { get; set; }
        public int Total { get; set; }
        public IEnumerable<T> DataList { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string RequestUrl { get; set; } = System.Web.HttpContext.Current.Request.Url.OriginalString;

        /// <summary>
        /// 分页页码Html
        /// </summary>
        /// <param name="cssClass">默认样式：jpager</param>
        /// <returns></returns>
        public string PagerHtml(string cssClass = "pager-default")
        {
            if (PageIndex == 0) PageIndex = 1;
            if (RequestUrl.IndexOf("?", StringComparison.Ordinal) == -1) RequestUrl += "?pageindex=1";
            else
            if (RequestUrl.IndexOf("&pageindex", StringComparison.Ordinal) == -1 && RequestUrl.IndexOf("?pageindex", StringComparison.Ordinal) == -1) RequestUrl += "&pageindex=1";

            var html = new StringBuilder();
            html.AppendFormat("<div class='{0}'>", cssClass);
            html.AppendFormat("<span class='page-info'>第{0}页/共{1}页</span>", PageIndex,Math.Ceiling((decimal)Total / PageSize));

            html.AppendFormat("<div class='page-content'>", cssClass);
            var pageLen = Math.Ceiling((double)Total / PageSize);
            html.AppendFormat("<a href='{0}' class='page-button page-index'> 首页 </a>", RequestUrl.GetUrl(PageIndex, 1));
            html.AppendFormat("<a href='{0}' class='page-button page-previous'> 上一页 </a>", RequestUrl.GetUrl(PageIndex, PageIndex < 2 ? 1 : PageIndex - 1));

            var si = PageIndex <= 6 ? 1 : PageIndex - 5;
            var ei = si + 9;

            while (si <= pageLen && si <= ei)
                html.AppendFormat(
                    si == PageIndex
                        ? "<a href=javascript:;'  class='page-current'> {1} </a>"
                        : "<a href='{0}'  class='page-other'> {1} </a>", RequestUrl.GetUrl(PageIndex, si), si++);

            html.AppendFormat("<a href='{0}' class='page-button page-next' > 下一页 </a>", RequestUrl.GetUrl(PageIndex, (int)(PageIndex > pageLen - 1 ? pageLen : PageIndex + 1)));

            html.AppendFormat("<a href='{0}' class='page-button page-last'> 尾页 </a>",
                Math.Abs(Total) <= 0
                ? RequestUrl.GetUrl(PageIndex, 1)
                : RequestUrl.GetUrl(PageIndex, (int)pageLen));


            html.Append(@"</div>");
            html.Append(@"</div>");


            return html.ToString();

        }

    }

}