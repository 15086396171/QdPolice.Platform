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
using Vickn.Platform.Dtos;

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
        public async Task BatchDeleteAsync(List<long> input)
        {
            await _kqMachineRepository.DeleteAsync(p => input.Contains(p.Id));
        }
        /// <summary>
        ///  新增考勤机
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<KqMachineForEidt> CreateAsync(KqMachineDto input)
        {
            var entity = input.MapTo<KqMachine>();
            await _kqMachineRepository.InsertAsync(entity);

            return new KqMachineForEidt {KqMachineDto = entity.MapTo<KqMachineDto>()};
        }

        /// <summary>
        /// 新增或更改考勤机
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateAsync(KqMachineDto input)
        {
            if (input.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
        }

        /// <summary>
        /// 修改考勤机
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateAsync(KqMachineDto input)
        {
            var entity = await _kqMachineRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);
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
        public async Task<KqMachineDto> GetForEditAsync(NullableIdDto<long> input)
        {
            KqMachineDto kqmachineEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _kqMachineRepository.GetAsync(input.Id.Value);
                kqmachineEditDto = entity.MapTo<KqMachineDto>();
            }
            else
            {
                kqmachineEditDto = new KqMachineDto();
                //考勤机编号+1
                var allList = await _kqMachineRepository.GetAllListAsync();
                if (allList.Count == 0)
                {
                  
                    kqmachineEditDto.KQMachineNo = 1001;
                }
                else
                {
                    var allKqMachineCount = allList.Count();
                    int kqmachineno = allList[allKqMachineCount - 1].KQMachineNo + 1;
                    kqmachineEditDto.KQMachineNo = kqmachineno;
                }
               

               

            }

            return kqmachineEditDto;
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
