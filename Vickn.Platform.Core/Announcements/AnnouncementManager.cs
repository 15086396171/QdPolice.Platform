/*
* 命名空间 :     Vickn.Platform.Announcements
* 类 名  称 :     AnnouncementManager
* 版      本 :      v1.0.0.0
* 文 件  名 :     AnnouncementManager.cs
* 描      述 :     通知公告管理
* 创建时间 :     2018/2/24 11:42:55
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace Vickn.Platform.Announcements
{
	 /// <summary>
    /// 通知公告管理
    /// </summary>
    public class AnnouncementManager : IDomainService
    {
        private readonly IRepository<Announcement, long> _announcementRepository;

        /// <summary>
        /// 初始化AnnouncementManager管理实例
        /// </summary>
        public AnnouncementManager(IRepository<Announcement, long> announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        //TODO:编写领域业务代码

        /// <summary>
        ///  初始化
        /// </summary>
        private void Init()
        {
        }
    }
}