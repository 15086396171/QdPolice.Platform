using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Vickn.PlatfForm.Utils.Pager;

namespace Vickn.Platform.Dtos
{
    /// <summary>
    /// 表示分页排序的Dto基类
    /// </summary>
    public class PagedAndSortedInputDto : IPagedResultRequest,ISortedResultRequest
    {

        /// <summary>
        /// Sorting information.
        ///             Should include sorting field and optionally a direction (ASC or DESC)
        ///             Can contain more than one field separated by comma (,).
        /// </summary>
        /// <example>
        /// Examples:
        ///             "Name"
        ///             "Name DESC"
        ///             "Name ASC, Age DESC"
        /// </example>
        public string Sorting { get; set; }

        /// <summary>
        /// 初始化分页排序的Dto
        /// </summary>
        protected PagedAndSortedInputDto()
        {
            MaxResultCount = PlatformConsts.DefaultPageSize;
        }

        /// <summary>
        /// Max expected result count.
        /// </summary>
        [Range(1, PlatformConsts.MaxPageSize)]
        public virtual int MaxResultCount { get; set; }

        /// <summary>
        /// Skip count (beginning of the page).
        /// </summary>
        [Range(0, int.MaxValue)]
        public virtual int SkipCount { get; set; }
    }
}