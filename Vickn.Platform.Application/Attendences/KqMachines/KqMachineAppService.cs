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
using Vickn.Platform.Attendances.KqMachines;
using Vickn.Platform.Attendences.KqMachines.Dtos;
using Vickn.Platform.Attendences.KqMachines;

namespace Vickn.Platform.Attendences.KqMachines
{
    /// <summary>
    /// 考勤机服务
    /// </summary>
    public class KqMachineAppService : PlatformAppServiceBase, IKqMachineAppService
    {
        private readonly IRepository<KqMachine, long> _kqMachineRepository;

        /// <summary>
        /// 初始化考勤机服务实例
        /// </summary>
        /// <param name="kqMachineRepository"></param>
        public KqMachineAppService(IRepository<KqMachine, long> kqMachineRepository)
        {
            _kqMachineRepository = kqMachineRepository;
        }

        /// <summary>
        /// 批量删除考勤机
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task BatchDeleteAsync(List<long> input)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///  新增考勤机
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<KqMachineForEidt> CreateAsync(KqMachineForEidt input)
        {
            var entity = input.KqMachineDto.MapTo<KqMachine>();
            await _kqMachineRepository.InsertAsync(entity);

            return new KqMachineForEidt {KqMachineDto = entity.MapTo<KqMachineDto>()};
        }

        /// <summary>
        /// 新增或更改考勤机
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateAsync(KqMachineForEidt input)
        {
            //if (input.KqMachineDto.Id.HasValue)
            //{
            //    await UpdateAsync(input);
            //}
            //else
            //{
            //    await DeleteAsync(input);
            //}
        }

        /// <summary>
        /// 修改考勤机
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateAsync(KqMachineForEidt input)
        {
            var entity = await _kqMachineRepository.GetAsync(input.KqMachineDto.Id.Value);
            input.KqMachineDto.MapTo(entity);
            await _kqMachineRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除考勤机
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeleteAsync(EntityDto<long> input)
        {
            await _kqMachineRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 通过指定id获取考勤机Dto信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<KqMachineDto> GetByIdAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 通过Id获取考勤机信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<KqMachineForEidt> GetForEditAsync(NullableIdDto<long> input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有的考勤机信息分页列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<KqMachineDto>> GetPagedAsync(GetKqMachineInputDto input)
        {
            var query = _kqMachineRepository.GetAll();
            query = query.WhereIf(!input.FilterText .IsNullOrEmpty(),p=>p.KQMachinePosition.Contains(input.FilterText));

            var KqMachineCount = await query.CountAsync();

            var KqMachines = await query.OrderBy(input.Sorting)
                .PageBy(input).ToListAsync();

            var KqMachineDtos = KqMachines.MapTo<List<KqMachineDto>>();

            return new PagedResultDto<KqMachineDto>(
                KqMachineCount,
                KqMachineDtos
            );
        }

       
    }
}
