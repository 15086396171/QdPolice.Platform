using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Vickn.PlatfForm.Utils.Pager;

namespace Vickn.Platform.Dtos
{
    /// <summary>
    /// 表示分页排序的Dto基类
    /// </summary>
    public class PagedAndSortedInputDto : IPagedResultRequest, IPagerInBase, ISortedResultRequest,IDatatable
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
        public PagedAndSortedInputDto()
        {
            MaxResultCount = PlatformConsts.DefaultPageSize;
            PageIndex = 1;
        }

        /// <summary>
        /// Max expected result count.
        /// </summary>
        [Range(1, PlatformConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }

        /// <summary>
        /// Skip count (beginning of the page).
        /// </summary>
        [Range(0, int.MaxValue)]
        public int SkipCount
        {
            get { return (PageIndex-1) * MaxResultCount; }
            set { }
        }

        public int PageIndex { get; set; }
        public int Draw { get; set; }
    }
}