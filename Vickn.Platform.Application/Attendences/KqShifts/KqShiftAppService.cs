using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Vickn.Platform.Announcements.Dtos;
using Vickn.Platform.Attendances.KqShifts;
using Vickn.Platform.Attendances.KqShifts.Authorization;
using Vickn.Platform.Attendences.KqShifts.Dtos;

namespace Vickn.Platform.Attendences.KqShifts
{
    /// <summary>
    /// 考勤班次服务
    /// </summary>
    public class KqShiftAppService : PlatformAppServiceBase, IKqShiftAppService
    {
      


        private readonly IRepository<KqShift,long> _KqShiftRepository;

        /// <summary>
        /// 初始化考勤班次服务实例
        /// </summary>
        public KqShiftAppService(IRepository<KqShift,long> KqShiftRepository)
        {
            _KqShiftRepository = KqShiftRepository;
        }


        /// <summary>
        /// 新增考勤班次
        /// </summary>
        public async Task<KqShiftForEidt> CreateAsync(KqShiftForEidt input)
        {
            var entity = input.KqShiftEditDto.MapTo<KqShift>();
            entity = await _KqShiftRepository.InsertAsync(entity);

            return new KqShiftForEidt { KqShiftEditDto = entity.MapTo<KqShiftEditDto>() };

        }


        /// <summary>
        /// 删除考勤班次
        /// </summary>
        public async Task DeleteAsync(EntityDto<long> input)
        {
            await _KqShiftRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除考勤班次
        /// </summary>
        public async Task BatchDeleteAsync(List<long> input)
        {
            await _KqShiftRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        /// <summary>
        /// 修改考勤班次
        /// </summary>
        public async Task UpdateAsync(KqShiftForEidt input)
        {
            var entity = await _KqShiftRepository.GetAsync(input.KqShiftEditDto.Id.Value);
            input.KqShiftEditDto.MapTo(entity);
            await _KqShiftRepository.UpdateAsync(entity);
           
        }

        /// <summary>
        /// 新增或更改考勤班次
        /// </summary>
        [AbpAuthorize(KqShiftAppPermissions.KqShift_CreateKqShift, KqShiftAppPermissions.KqShift_EditKqShift)]
        public async Task CreateOrUpdateAsync(KqShiftForEidt input)
        {
            if (input.KqShiftEditDto.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
        }

        /// <summary>
        /// 通过Id获取考勤班次信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<KqShiftForEidt> GetForEditAsync(NullableIdDto<long> input)
        {
            KqShiftEditDto kqshiftEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _KqShiftRepository.GetAsync(input.Id.Value);
                kqshiftEditDto = entity.MapTo<KqShiftEditDto>();
            }
            else
            {
                kqshiftEditDto = new KqShiftEditDto()
                {
                    KqShiftUsers = new List<KqShiftUserEidtDto>()
                };
            }
            return new KqShiftForEidt { KqShiftEditDto = kqshiftEditDto };
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
        public async Task<PagedResultDto<KqShiftDto>> GetPagedAsync(GetKqShiftInputDto input)
        {
            var query = _KqShiftRepository.GetAll();

            //TODO:根据传入的参数添加过滤条件
            query = query.WhereIf(!input.FilterText.IsNullOrEmpty(), p => p.ShiftName.Contains(input.FilterText));

            var kqshiftCount = await query.CountAsync();

            var kqshifts = await query.OrderBy(input.Sorting)
                .PageBy(input).ToListAsync();

            var KqShiftDtos = kqshifts.MapTo<List<KqShiftDto>>();

            return new PagedResultDto<KqShiftDto>(
            kqshiftCount,
            KqShiftDtos
            );
        }

       
    }
}
