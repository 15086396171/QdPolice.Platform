using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Attendences.KqMachines.Dtos;

namespace Vickn.Platform.Attendences.KqMachines
{
    /// <summary>
    /// 考勤机接口
    /// </summary>
   public interface IKqMachineAppService: IApplicationService
    {
        /// <summary>
        /// 获取所有的班次信息分页列表
        /// </summary>
        /// <returns></returns>
        Task<PagedResultDto<KqMachineDto>> GetPagedAsync(GetKqMachineInputDto input);

        /// <summary>
        /// 通过指定id获取考勤班次Dto信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<KqMachineDto> GetByIdAsync(EntityDto<long> input);

        /// <summary>
        /// 新增考勤班次
        /// </summary>
        Task<KqMachineForEidt> CreateAsync(KqMachineForEidt input);

        /// <summary>
        /// 修改考勤班次
        /// </summary>
        Task UpdateAsync(KqMachineForEidt input);

        /// <summary>
        /// 删除考勤班次
        /// </summary>
        Task DeleteAsync(EntityDto<long> input);

        /// <summary>
        /// 批量删除考勤机
        /// </summary>
        Task BatchDeleteAsync(List<long> input);

        /// <summary>
        /// 新增或更改考勤机
        /// </summary>
        Task CreateOrUpdateAsync(KqMachineForEidt input);

        /// <summary>
        /// 通过Id获取考勤班次信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<KqMachineForEidt> GetForEditAsync(NullableIdDto<long> input);
    }
}
