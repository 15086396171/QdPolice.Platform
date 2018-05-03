/*
* 命名空间 :     Vickn.Platform.Schedules.SchedulingPosts
* 类 名  称 :     
* 版      本 :      v1.0.0.0
* 文 件  名 :     _SchedulingPostReadme.cs
* 描      述 :     岗位设置Readme文件
* 创建时间 :     2018/5/3 15:40:49
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.Schedules.SchedulingPosts
{
    // 1.Core层权限配置
	// 2.Core层本地化
	// 3.EntityFrame层数据映射配置
	// 4.Application层注入权限
	// 5.Web层菜单配置
	//TODO:admin后端的导航栏目设计

	/*
	//无次级导航属性
	   var schedulingPost=new MenuItemDefinition(
                SchedulingPostAppPermissions.SchedulingPost,
                L("SchedulingPost"),
				url:"schedulingPostInfo",
				icon:"icon-grid",
				 requiredPermissionName: SchedulingPostAppPermissions.SchedulingPost
				);

*/
				//有下级菜单
            /*

			   var schedulingPost=new MenuItemDefinition(
                SchedulingPostAppPermissions.SchedulingPost,
                L("SchedulingPost"),			
				icon:"icon-grid"				
				);

				schedulingPost.AddItem(
			new MenuItemDefinition(
			SchedulingPostAppPermissions.SchedulingPost,
			L("SchedulingPost"),
			"icon-star",
			"schedulingPost",
			requiredPermissionName: SchedulingPostAppPermissions.SchedulingPost));
	

			
			*/
			
	
	
	
	//配置权限模块初始化
	
 //TODO:★需要到请将以下内容剪切到AuthorizationProvider.AddAuthorizationProviders	中
 //   Configuration.Authorization.Providers.Add<SchedulingPostAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/zh-cn.xml
/*
    <!-- 岗位设置管理 -->


	    <text name="	SchedulingPostHeaderInfo" value="岗位设置信息列表" />
		    <text name="SchedulingPostDeleteWarningMessage" value="岗位设置名称: {0} 将被删除,是否确定删除它。" />

			    <text name="SchedulingPostName" value="岗位设置" />

<!--//用于表格展示的数据信息的标题-->
					<text name="SchedulingPost.PostName" value="岗位名称" />
				 	<text name="SchedulingPost.LastModificationTime" value="最后编辑时间" />
				 	<text name="SchedulingPost.CreationTime" value="创建时间" />
				 

    <text name="SchedulingPost" value="岗位设置管理" />
    <text name="CreateSchedulingPost" value="添加岗位设置" />
    <text name="EditSchedulingPost" value="编辑岗位设置" />
    <text name="DeleteSchedulingPost" value="删除岗位设置" />
*/

/*
    <!-- 岗位设置english管理 -->
		    <text name="	SchedulingPostHeaderInfo" value="岗位设置List" />


    <text name="SchedulingPost" value="ManagementSchedulingPost" />
    <text name="CreateSchedulingPost" value="CreateSchedulingPost" />
    <text name="EditSchedulingPost" value="EditSchedulingPost" />
    <text name="DeleteSchedulingPost" value="DeleteSchedulingPost" />
*/
}