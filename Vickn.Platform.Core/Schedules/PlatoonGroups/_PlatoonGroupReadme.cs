/*
* 命名空间 :     Vickn.Platform.Schedules.PlatoonGroups
* 类 名  称 :     
* 版      本 :      v1.0.0.0
* 文 件  名 :     _PlatoonGroupReadme.cs
* 描      述 :     排班组Readme文件
* 创建时间 :     2018/5/3 17:22:53
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.Schedules.PlatoonGroups
{
    // 1.Core层权限配置
	// 2.Core层本地化
	// 3.EntityFrame层数据映射配置
	// 4.Application层注入权限
	// 5.Web层菜单配置
	//TODO:admin后端的导航栏目设计

	/*
	//无次级导航属性
	   var platoonGroup=new MenuItemDefinition(
                PlatoonGroupAppPermissions.PlatoonGroup,
                L("PlatoonGroup"),
				url:"platoonGroupInfo",
				icon:"icon-grid",
				 requiredPermissionName: PlatoonGroupAppPermissions.PlatoonGroup
				);

*/
				//有下级菜单
            /*

			   var platoonGroup=new MenuItemDefinition(
                PlatoonGroupAppPermissions.PlatoonGroup,
                L("PlatoonGroup"),			
				icon:"icon-grid"				
				);

				platoonGroup.AddItem(
			new MenuItemDefinition(
			PlatoonGroupAppPermissions.PlatoonGroup,
			L("PlatoonGroup"),
			"icon-star",
			"platoonGroup",
			requiredPermissionName: PlatoonGroupAppPermissions.PlatoonGroup));
	

			
			*/
			
	
	
	
	//配置权限模块初始化
	
 //TODO:★需要到请将以下内容剪切到AuthorizationProvider.AddAuthorizationProviders	中
 //   Configuration.Authorization.Providers.Add<PlatoonGroupAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/zh-cn.xml
/*
    <!-- 排班组管理 -->


	    <text name="	PlatoonGroupHeaderInfo" value="排班组信息列表" />
		    <text name="PlatoonGroupDeleteWarningMessage" value="排班组名称: {0} 将被删除,是否确定删除它。" />

			    <text name="PlatoonGroupName" value="排班组" />

<!--//用于表格展示的数据信息的标题-->
					<text name="PlatoonGroup.PlatoonGroupName" value="排班组名称" />
				 	<text name="PlatoonGroup.GroupLeaderName" value="组长名称" />
				 	<text name="PlatoonGroup.GroupMember" value="组员list" />
				 	<text name="PlatoonGroup.LastModificationTime" value="最后编辑时间" />
				 	<text name="PlatoonGroup.CreationTime" value="创建时间" />
				 

    <text name="PlatoonGroup" value="排班组管理" />
    <text name="CreatePlatoonGroup" value="添加排班组" />
    <text name="EditPlatoonGroup" value="编辑排班组" />
    <text name="DeletePlatoonGroup" value="删除排班组" />
*/

/*
    <!-- 排班组english管理 -->
		    <text name="	PlatoonGroupHeaderInfo" value="排班组List" />


    <text name="PlatoonGroup" value="ManagementPlatoonGroup" />
    <text name="CreatePlatoonGroup" value="CreatePlatoonGroup" />
    <text name="EditPlatoonGroup" value="EditPlatoonGroup" />
    <text name="DeletePlatoonGroup" value="DeletePlatoonGroup" />
*/
}