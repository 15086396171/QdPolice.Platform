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
using Vickn.Platform.PbManagement.PbTitles;
using Vickn.Platform.PbManagement.Positions;

namespace Vickn.Platform.PbManagement.PbPositions
{
    /// <summary>
    /// 排班岗位管理
    /// </summary>
    public class PbPositionManager : IDomainService
    {
        private readonly IRepository<PbPosition, int> _pbPositionRepository;
        private readonly IRepository<Position> _positionRepository;
        private readonly IRepository<PbTitle> _pbTitleRepository;

        /// <summary>
        /// 初始化PbPositionManager管理实例
        /// </summary>
        public PbPositionManager(IRepository<PbPosition, int> pbPositionRepository, IRepository<Position> positionRepository, IRepository<PbTitle> pbTitleRepository)
        {
            _pbPositionRepository = pbPositionRepository;
            _positionRepository = positionRepository;
            _pbTitleRepository = pbTitleRepository;
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
            foreach (var position in _positionRepository.GetAllList())
            {
                await _pbPositionRepository.InsertAsync(new PbPosition()
                {
                    PositionId = position.Id,
                    Month = pbTitle.Month,
                    PbTitleId = pbTitleId
                });
            }
        }
    }
}