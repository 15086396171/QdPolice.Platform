/*
* 命名空间 :     Vickn.Platform.Announcements
* 类 名  称 :     
* 版      本 :      v1.0.0.0
* 文 件  名 :     _AnnouncementReadme.cs
* 描      述 :     通知公告Readme文件
* 创建时间 :     2018/2/24 11:42:56
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.Announcements
{
    // 1.Core层权限配置
	// 2.Core层本地化
	// 3.EntityFrame层数据映射配置
	// 4.Application层注入权限
	// 5.Web层菜单配置
	//TODO:admin后端的导航栏目设计

	/*
	//无次级导航属性
	   var announcement=new MenuItemDefinition(
                AnnouncementAppPermissions.Announcement,
                L("Announcement"),
				url:"announcementInfo",
				icon:"icon-grid",
				 requiredPermissionName: AnnouncementAppPermissions.Announcement
				);

*/
				//有下级菜单
            /*

			   var announcement=new MenuItemDefinition(
                AnnouncementAppPermissions.Announcement,
                L("Announcement"),			
				icon:"icon-grid"				
				);

				announcement.AddItem(
			new MenuItemDefinition(
			AnnouncementAppPermissions.Announcement,
			L("Announcement"),
			"icon-star",
			"announcement",
			requiredPermissionName: AnnouncementAppPermissions.Announcement));
	

			
			*/
			
	
	
	
	//配置权限模块初始化
	
 //TODO:★需要到请将以下内容剪切到AuthorizationProvider.AddAuthorizationProviders	中
 //   Configuration.Authorization.Providers.Add<AnnouncementAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/zh-cn.xml
/*
    <!-- 通知公告管理 -->


	    <text name="	AnnouncementHeaderInfo" value="通知公告信息列表" />
		    <text name="AnnouncementDeleteWarningMessage" value="通知公告名称: {0} 将被删除,是否确定删除它。" />

			    <text name="AnnouncementName" value="通知公告" />

<!--//用于表格展示的数据信息的标题-->
					<text name="Announcement.Title" value="标题" />
				 	<text name="Announcement.Content" value="内容" />
				 	<text name="Announcement.AnnouncementUsers" value="AnnouncementUsers" />
				 	<text name="Announcement.LastModificationTime" value="最后编辑时间" />
				 	<text name="Announcement.CreationTime" value="创建时间" />
				 

    <text name="Announcement" value="通知公告管理" />
    <text name="CreateAnnouncement" value="添加通知公告" />
    <text name="EditAnnouncement" value="编辑通知公告" />
    <text name="DeleteAnnouncement" value="删除通知公告" />
*/

/*
    <!-- 通知公告english管理 -->
		    <text name="	AnnouncementHeaderInfo" value="通知公告List" />


    <text name="Announcement" value="ManagementAnnouncement" />
    <text name="CreateAnnouncement" value="CreateAnnouncement" />
    <text name="EditAnnouncement" value="EditAnnouncement" />
    <text name="DeleteAnnouncement" value="DeleteAnnouncement" />
*/
}