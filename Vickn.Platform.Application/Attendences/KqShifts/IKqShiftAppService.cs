using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Announcements.Dtos;
using Vickn.Platform.Attendences.KqShifts.Dtos;

namespace Vickn.Platform.Attendences.KqShifts
{
    /// <summary>
    /// 考勤班次接口
    /// </summary>
   public interface IKqShiftAppService: IApplicationService
    {
        /// <summary>
        /// 获取所有的班次信息分页列表
        /// </summary>
        /// <returns></returns>
        Task<PagedResultDto<KqShiftEditDto>> GetPagedAsync(GetAnnouncementInput input);

        /// <summary>
        /// 通过指定id获取考勤班次Dto信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<KqShiftDto> GetByIdAsync(EntityDto<long> input);

        /// <summary>
        /// 新增考勤班次
        /// </summary>
        Task<KqShiftForEidt> CreateAsync(KqShiftForEidt input);

        /// <summary>
        /// 修改考勤班次
        /// </summary>
        Task UpdateAsync(AnnouncementForEdit input);

        /// <summary>
        /// 删除考勤班次
        /// </summary>
        Task DeleteAsync(EntityDto<long> input);

        /// <summary>
        /// 批量删除考勤班次
        /// </summary>
        Task BatchDeleteAsync(List<long> input);
    }
}
