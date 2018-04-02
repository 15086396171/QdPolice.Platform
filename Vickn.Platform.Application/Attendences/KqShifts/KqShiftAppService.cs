using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Vickn.Platform.Announcements.Dtos;
using Vickn.Platform.Attendences.KqShifts.Dtos;

namespace Vickn.Platform.Attendences.KqShifts
{
    /// <summary>
    /// 考勤班次服务
    /// </summary>
    public class KqShiftAppService : PlatformAppServiceBase, IKqShiftAppService
    {
        /// <summary>
        /// 批量删除考勤班次
        /// </summary>
        public Task BatchDeleteAsync(List<long> input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增考勤班次
        /// </summary>
        public Task<KqShiftForEidt> CreateAsync(KqShiftForEidt input)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 删除考勤班次
        /// </summary>
        public Task DeleteAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 通过指定id获取考勤班次Dto信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<KqShiftDto> GetByIdAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有的班次信息分页列表
        /// </summary>
        /// <returns></returns>
        public Task<PagedResultDto<KqShiftEditDto>> GetPagedAsync(GetAnnouncementInput input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改考勤班次
        /// </summary>
        public Task UpdateAsync(AnnouncementForEdit input)
        {
            throw new NotImplementedException();
        }
    }
}
