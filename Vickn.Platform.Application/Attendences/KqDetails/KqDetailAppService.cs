using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Vickn.Platform.Attendances.KQDetails;
using Vickn.Platform.Attendences.KqDetails.Dtos;
using Vickn.Platform.Sessions.Dto;
using Vickn.Platform.Users.Dtos;

namespace Vickn.Platform.Attendences.KqDetails
{
    public class KqDetailAppService : PlatformAppServiceBase,IKqDetailAppService
    {
        private readonly IRepository<KqAllDetail> _KqAllDeatilRepository;

        /// <summary>
        /// 初始化考勤班次服务实例
        /// </summary>
        public KqDetailAppService(IRepository<KqAllDetail> KqAllDeatilRepository)
        {
            _KqAllDeatilRepository = KqAllDeatilRepository;
        }

        /// <summary>
        /// 添加考勤流水记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ResultDto> CreateAllDetailAsync(KqDetailForEidt input)
        {
            var user = await GetCurrentUserAsync();
            string NowUserName = user.Surname;

            input.KqDetailEditDto.UserName = NowUserName;
            var entity = input.KqDetailEditDto.MapTo<KqAllDetail>();
            await _KqAllDeatilRepository.InsertAsync(entity);
            return new ResultDto()
            {
                IsOk = true
            };
        }

       
    }
}
