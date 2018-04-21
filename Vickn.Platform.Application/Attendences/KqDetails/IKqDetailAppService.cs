using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.Attendences.KqDetails.Dtos;

namespace Vickn.Platform.Attendences.KqDetails
{
    /// <summary>
    /// 考勤流水服务
    /// </summary>
    public interface IKqDetailAppService : IApplicationService
    {
        /// <summary>
        /// 新增考勤流水记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ResultDto> CreateAllDetailAsync(KqDetailDto input);

        /// <summary>
        /// 新增或修改考勤记录信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateAsync(KqDetailEditDtos input);

        /// <summary>
        /// 新增考勤记录(第一次打卡)
        /// </summary>
        Task CreateAsync(KqDetailEditDtos input);

        /// <summary>
        /// 修改考勤记录(二次打卡)
        /// </summary>
        Task UpdateAsync(int KqRecordId, KqDetailEditDtos input);

        ///// <summary>
        ///// 获取所有的考勤流水信息分页列表
        ///// </summary>
        ///// <returns></returns>
        //Task<PagedResultDto<KqDetailEditDto>> GetPagedAsync(GetKqDetailInputDto input);
    }
}
