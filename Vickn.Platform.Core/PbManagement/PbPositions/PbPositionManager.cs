/*
* 命名空间 :     Vickn.Platform.PbManagement.PbPositions
* 类 名  称 :     PbPositionManager
* 版      本 :      v1.0.0.0
* 文 件  名 :     PbPositionManager.cs
* 描      述 :     排班岗位管理
* 创建时间 :     2018/5/6 15:05:47
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Zero.Configuration;
using Vickn.Platform.PbManagement.PbTitles;
using Abp.Organizations;

namespace Vickn.Platform.PbManagement.PbPositions
{
    /// <summary>
    /// 排班岗位管理
    /// </summary>
    public class PbPositionManager : IDomainService
    {
        private readonly IRepository<PbPosition, long> _pbPositionRepository;
     
        private readonly IRepository<PbTitle> _pbTitleRepository;
        private readonly IRepository<OrganizationUnit, long> _organizationUnitsRepository;

        /// <summary>
        /// 初始化PbPositionManager管理实例
        /// </summary>
        public PbPositionManager(IRepository<PbPosition, long> pbPositionRepository,  IRepository<PbTitle> pbTitleRepository, IRepository<OrganizationUnit, long> organizationUnitsRepository)
        {
            _pbPositionRepository = pbPositionRepository;
         
            _pbTitleRepository = pbTitleRepository;
            _organizationUnitsRepository = organizationUnitsRepository;
        }

        //TODO:编写领域业务代码

        /// <summary>
        ///  初始化
        /// </summary>
        private void Init()
        {
        }

        public async Task GeneratePoPositions(int pbTitleId)
        {
            var pbTitle = await _pbTitleRepository.GetAsync(pbTitleId);
            foreach (var organization in _organizationUnitsRepository.GetAllList())
            {

                await _pbPositionRepository.InsertAsync(new PbPosition()
                {
                    OrganizationUnitName=organization.DisplayName,
                    OrganizationUnitId = organization.Id,
                    Month = pbTitle.Month,
                    PbTitleId = pbTitleId
                });
            }
        }
    }
}