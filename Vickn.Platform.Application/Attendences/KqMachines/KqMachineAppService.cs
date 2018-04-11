using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Vickn.Platform.Attendances.KqMachines;
using Vickn.Platform.Attendences.KqMachines.Dtos;

namespace Vickn.Platform.Attendences.KqMachines
{
    /// <summary>
    /// 考勤机服务
    /// </summary>
    public class KqMachineAppService : IKqMachineAppService
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

        public Task BatchDeleteAsync(List<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<KqMachineForEidt> CreateAsync(KqMachineForEidt input)
        {
            throw new NotImplementedException();
        }

        public Task CreateOrUpdateAsync(KqMachineForEidt input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<KqMachineDto> GetByIdAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<KqMachineForEidt> GetForEditAsync(NullableIdDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<KqMachineDto>> GetPagedAsync(GetKqMachineInputDto input)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(KqMachineForEidt input)
        {
            throw new NotImplementedException();
        }
    }
}
