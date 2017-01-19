using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace Vickn.PlatfForm.Utils.Pager
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


    public static class PagedResultRequestExtension
    {
        /// <summary>
        /// 返回分页列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="pagedResultDto">页面显示Dto</param>
        /// <param name="pagedResultRequest">分页排序的Dto</param>
        /// <returns></returns>
        public static PagerResult<T,TInput> ToPagedList<T,TInput>(this PagedResultDto<T> pagedResultDto, TInput pagedResultRequest) where TInput:IPagedResultRequest,IPagerInBase
        {
            return new PagerResult<T,TInput>()
            {
                DataList = pagedResultDto.Items,
                TotalCount = pagedResultDto.TotalCount,
                PageIndex = pagedResultRequest.PageIndex,
                PageSize = pagedResultRequest.MaxResultCount    ,
                Input = pagedResultRequest
            };
        }
    }


    /// <summary>
    /// 分页列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TInput"></typeparam>
    public class PagerResult<T,TInput> where TInput:IPagedResultRequest
    {
        public int TotalCount { get; set; }
        public IEnumerable<T> DataList { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public TInput Input { get; set; }
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
         

            html.AppendFormat("<div class='page-content'>", cssClass);
            var pageLen = Math.Ceiling((double)TotalCount / PageSize);
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
                Math.Abs(TotalCount) <= 0
                ? RequestUrl.GetUrl(PageIndex, 1)
                : RequestUrl.GetUrl(PageIndex, (int)pageLen));

            html.AppendFormat("<span class='page-info'>共{0}页</span>", Math.Ceiling((decimal)TotalCount / PageSize));
            html.Append(@"</div>");
            html.Append(@"</div>");


            return html.ToString();

        }

    }

}